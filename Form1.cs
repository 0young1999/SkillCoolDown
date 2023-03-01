using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown
{
	public partial class Form1 : Form
	{
		// keybord hook
		private static KeybordHooker _hooker = KeybordHooker.GetKeybordHooker();

		// ctrl key stop watch
		private static Stopwatch _ctrlWatch = new Stopwatch();

		// space key stop watch
		private static Stopwatch _spaceWatch = new Stopwatch();

		// 쿨타임 돌고 있는 스킬들
		private static List<LeftSkillCoolDownClass> _leftSkillCoolDown = new List<LeftSkillCoolDownClass>();
		private object _leftSkillCoolDownLock = new object();

		// 설정
		private SetData data = SetData.GetInstance();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InPutKeyControll.Enabled = true;

			if (!data.ReadSettingData())
			{
				data.SaveSettingData();
			}

			LBHookState.ForeColor = Color.Blue;

			_hooker.SetHook();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			InPutKeyControll.Enabled = false;
			_hooker.UnHook();
		}

		private void BTGameMode_Click(object sender, EventArgs e)
		{
			// 상단바 및 버튼 안보이게 하기
			this.FormBorderStyle = FormBorderStyle.None;
			BTGameMode.Visible = false;
			BTSetting.Visible = false;
			BTClear.Visible = false;
		}

		private void BTSetting_Click(object sender, EventArgs e)
		{
			_hooker.UnHook();
			(new settForm()).ShowDialog();
			_hooker.SetHook();
		}

		private void ControllLeftSkillCoolDown(LeftSkillCoolDownClass skill)
		{
			lock (_leftSkillCoolDownLock)
			{
				string name = "";
				long time = 0;
				bool runAble = false;

				// 화면갱신
				if (skill == null)
				{
					for (int i = 0; i < _leftSkillCoolDown.Count; i++)
					{
						_leftSkillCoolDown[i].GetLeftCoolDown(ref name, ref time, ref runAble);

						if (runAble)
						{
							LBCoolDown.Items[i] = name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000);
							continue;
						}

						if (time < 0)
						{
							_leftSkillCoolDown.Remove(_leftSkillCoolDown[i]);
							LBCoolDown.Items.RemoveAt(i);
							continue;
						}

						LBCoolDown.Items[i] = name + " : " + string.Format("{0:0.0}", (float)time / 1000);
					}
					return;
				}

				// 스킬 쿨 추가 중복 방지
				for (int i = 0; i < _leftSkillCoolDown.Count; i++)
				{
					if (skill.name == _leftSkillCoolDown[i].name) { return; }
				}
				_leftSkillCoolDown.Add(skill);
				skill.GetLeftCoolDown(ref name, ref time, ref runAble);
				LBCoolDown.Items.Add(name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000));
			}
		}

		private void TimerSkillCoolDown_Tick(object sender, EventArgs e)
		{
			ControllLeftSkillCoolDown(null);
		}

		private void InPutKeyControll_Tick(object sender, EventArgs e)
		{
			int inputKey = _hooker.GetInputKey();
			bool hookState = _hooker.GetHookState();

			// ctrl 인식
			if (inputKey == 162)
			{
				if (!_ctrlWatch.IsRunning) _ctrlWatch.Start();
				else _ctrlWatch.Restart();
			}

			// space 인식
			else if (inputKey == 32)
			{
				if (!_spaceWatch.IsRunning) _spaceWatch.Start();
				else _spaceWatch.Restart();
			}


			// 상단바 및 버튼 보이게 하기
			if (inputKey == 27)
			{
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				BTGameMode.Visible = true;
				BTSetting.Visible = true;
				BTClear.Visible = true;
			}

			// 훅 잠금
			else if (inputKey == data.intHookPause)
			{
				if (hookState)
				{
					LBHookState.ForeColor = Color.Red;
					_hooker.SetHookState(false);
				}
				else
				{
					LBHookState.ForeColor = Color.Blue;
					_hooker.SetHookState(true);
					if (_ctrlWatch.IsRunning) { _ctrlWatch.Reset(); }
					if (_spaceWatch.IsRunning) { _spaceWatch.Reset(); }
				}
			}

			// 훅 잠김 상태
			else if (!hookState)
			{
				return;
			}

			// ctrl 인식 해제
			else if (_ctrlWatch.IsRunning && (_ctrlWatch.ElapsedMilliseconds >= 1000 || (inputKey != 162 && inputKey != 0 && inputKey != 32)))
			{
				if (_ctrlWatch.IsRunning)
				{
					_ctrlWatch.Reset();
				}
			}

			// space 인식 해제
			else if (_spaceWatch.IsRunning && (_spaceWatch.ElapsedMilliseconds >= 1000 || (inputKey != 162 && inputKey != 0 && inputKey != 32)))
			{
				if (_spaceWatch.IsRunning)
				{
					_spaceWatch.Reset();
				}
			}

			// 질풍가도
			else if (data.galeRoadEnable &&
				((_ctrlWatch.IsRunning && _ctrlWatch.ElapsedMilliseconds < 1000 && inputKey == 32) ||
				(_spaceWatch.IsRunning && _spaceWatch.ElapsedMilliseconds < 1000 && inputKey == 162)))
			{
				ControllLeftSkillCoolDown(
					new LeftSkillCoolDownClass(
						false,
						"질풍가도",
						data.galeRoadCoolDown * 1000,
						data.galeRoadCoolDown * 1000));
				_ctrlWatch.Reset();
			}

			// 상단바 및 버튼 안보이게 하기
			else if (inputKey == data.intGameMode)
			{
				this.FormBorderStyle = FormBorderStyle.None;
				BTGameMode.Visible = false;
				BTSetting.Visible = false;
				BTClear.Visible = false;
			}

			// 마지막 스킬 삭제
			else if (inputKey == data.intDelete && _leftSkillCoolDown.Count > 0)
			{
				lock (_leftSkillCoolDownLock)
				{
					LBCoolDown.Items.RemoveAt(_leftSkillCoolDown.Count - 1);
					_leftSkillCoolDown.RemoveAt(_leftSkillCoolDown.Count - 1);
				}
			}

			// 맵 로딩 보정
			else if (inputKey == data.intCorrection)
			{
				lock (_leftSkillCoolDownLock)
				{
					for (int i = 0; i < _leftSkillCoolDown.Count; i++)
						_leftSkillCoolDown[i].coolDown += 10000;
				}
			}

			else if (inputKey != 0)
			{
				for (int i = 0; i < 10; i++)
				{
					if (data.skillEnable[i] && data.intSkillBind[i] == inputKey)
					{
						ControllLeftSkillCoolDown(
							new LeftSkillCoolDownClass(
								data.skillUnique[i],
								data.skillName[i],
								data.skillCoolDown[i] * 1000,
								data.skillDuration[i] * 1000));
					}
				}
			}

			_hooker.SetInputKey(0);
		}

		private void BTClear_Click(object sender, EventArgs e)
		{
			_leftSkillCoolDown.Clear();
			LBCoolDown.Items.Clear();
		}
	}

	class LeftSkillCoolDownClass
	{
		public bool unique = false;
		public string name = "";
		public long coolDown = 0;   // ms, 1000ms == 1s
		public long duration = 0;   // ms, 1000ms == 1s
		private Stopwatch Stopwatch = new Stopwatch();

		private LeftSkillCoolDownClass() { }
		public LeftSkillCoolDownClass(bool unique, string name, long coolDown, long duration)
		{
			this.unique = unique;
			this.name = name;
			this.coolDown = coolDown;
			this.duration = duration;

			Stopwatch.Start();
		}
		~LeftSkillCoolDownClass()
		{
			Stopwatch.Stop();
		}

		private object locker = new object();

		public void GetLeftCoolDown(ref string name, ref long time, ref bool runAble)
		{
			lock (locker)
			{
				name = this.name;
				if (duration > Stopwatch.ElapsedMilliseconds)
				{
					time = duration - Stopwatch.ElapsedMilliseconds;
					runAble = true;
					return;
				}
				if (unique)
				{
					time = coolDown + duration - Stopwatch.ElapsedMilliseconds;
				}
				else
				{
					time = coolDown - Stopwatch.ElapsedMilliseconds;
				}
				runAble = false;
			}
		}
	}
}