using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown
{
	public partial class Form1 : Form
	{
		// keybord hook
		private static KeybordHooker _hooker = KeybordHooker.GetKeybordHooker();

		// ctrl space state
		private bool _ctrlState = false;
		private bool _spaceState = false;

		// game mode state
		private bool _gameModeState = false;

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
			if (!data.ReadSettingData())
			{
				data.SaveSettingData();
			}

			LBHookState.ForeColor = Color.Blue;

			_hooker.SetHook();

			KeybordHooker.UpdataKeybordHookEvent += new EventHandler<KeybordHooker.KeybordHookEventArg>(UpdateKey);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_hooker.UnHook();
		}

		private void BTGameMode_Click(object sender, EventArgs e)
		{
			// 상단바 및 버튼 안보이게 하기
			this.FormBorderStyle = FormBorderStyle.None;
			BTGameMode.Visible = false;
			BTSetting.Visible = false;
			BTClear.Visible = false;
			_gameModeState = true;
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

		private void BTClear_Click(object sender, EventArgs e)
		{
			_leftSkillCoolDown.Clear();
			LBCoolDown.Items.Clear();
		}

		private void UpdateKey(object sender, KeybordHooker.KeybordHookEventArg e)
		{
			// ctrl && space
			if (e._keyCode == 162) Invoke((MethodInvoker)delegate { _ctrlState = e._lParam == (IntPtr)0x100 ? true : false; });
			if (e._keyCode == 32) Invoke((MethodInvoker)delegate { _spaceState = e._lParam == (IntPtr)0x100 ? true : false; });

			// 훅 장금
			if (e._lParam == (IntPtr)0x101 && e._keyCode == data.intHookPause)
			{
				_hooker.SetHookState(!_hooker.GetHookState());
				LBHookState.Invoke((MethodInvoker)delegate { LBHookState.ForeColor = _hooker.GetHookState() ? Color.Red : Color.Blue; });
			}
			if (_hooker.GetHookState())
			{
				return;
			}
			
			// 질풍가도
			if (_spaceState && _ctrlState)
			{
				Invoke((MethodInvoker)delegate
				{
					ControllLeftSkillCoolDown(
					new LeftSkillCoolDownClass(
						false,
						"질풍가도",
						data.galeRoadCoolDown * 1000,
						data.galeRoadCoolDown * 1000));
				});
				return;
			}

			if (e._lParam == (IntPtr)0x101)
			{
				// 게임모드
				if (e._keyCode == data.intGameMode)
				{
					Invoke((MethodInvoker)delegate
					{
						if (_gameModeState)
						{
							FormBorderStyle = FormBorderStyle.FixedSingle;
							BTGameMode.Visible = true;
							BTSetting.Visible = true;
							BTClear.Visible = true;
						}
						else
						{
							FormBorderStyle = FormBorderStyle.None;
							BTGameMode.Visible = false;
							BTSetting.Visible = false;
							BTClear.Visible = false;
						}
						_gameModeState = !_gameModeState;
					});
				}
				// 마지막 스킬 삭제
				else if (e._keyCode == data.intDelete)
				{
					Invoke((MethodInvoker)delegate
					{
						lock (_leftSkillCoolDownLock)
						{
							LBCoolDown.Items.RemoveAt(_leftSkillCoolDown.Count - 1);
							_leftSkillCoolDown.RemoveAt(_leftSkillCoolDown.Count - 1);
						}
					});
				}
				// 맵 로딩 보정
				else if (e._keyCode == data.intCorrection)
				{
					Invoke((MethodInvoker)delegate
					{
						lock (_leftSkillCoolDownLock)
						{
							for (int i = 0; i < _leftSkillCoolDown.Count; i++)
								_leftSkillCoolDown[i].coolDown += 20000;
						}
					});
				}
				else if (e._keyCode != 0)
				{
					Invoke((MethodInvoker)delegate
					{
						for (int i = 0; i < 10; i++)
						{
							if (data.skillEnable[i] && data.intSkillBind[i] == e._keyCode)
							{
								ControllLeftSkillCoolDown(
									new LeftSkillCoolDownClass(
										data.skillUnique[i],
										data.skillName[i],
										data.skillCoolDown[i] * 1000,
										data.skillDuration[i] * 1000));
							}
						}
					});
				}
			}
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