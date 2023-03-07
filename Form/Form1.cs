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
		private static keyboardHooker _hooker = keyboardHooker.GetKeyboardHooker();

		// ctrl space state
		private bool _ctrlState = false;
		private bool _spaceState = false;

		// game mode state
		private bool _gameModeState = false;
		public bool GetGameModeState() { return _gameModeState; }

		// 쿨타임 돌고 있는 스킬들
		private static List<LeftSkillCoolDownClass> _leftSkillCoolDown = new List<LeftSkillCoolDownClass>();
		private object _leftSkillCoolDownLock = new object();

		// 설정
		private SetData _data = SetData.GetInstance();

		// server
		private OthersPlayerSkill _playerSkill;
		private TCPClient _tcPClient = TCPClient.GetInstance();
		private bool _gameServerState = true;

		private Form1()
		{
			InitializeComponent();
		}
		private static Form1 _instance;
		public static Form1 GetInstance()
		{
			if (_instance == null) _instance = new Form1();
			return _instance;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!_data.ReadSettingData())
			{
				_data.SaveSettingData();
			}

			LBHookState.ForeColor = Color.Blue;

			List<int> list = new List<int>();
			list.Add(_data.intDelete);
			list.Add(_data.intGameMode);
			list.Add(_data.intCorrection);
			_hooker.SetBlockKey(list);
			_hooker.SetHook();

			keyboardHooker.UpdataKeyboardHookEvent += new EventHandler<keyboardHooker.KeyboardHookEventArg>(UpdateKey);
			TCPClient._ReqeustSkillNewEvent += new EventHandler<TCPClient.ReqeustSkillNewEventArg>(UpdateSkill);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_hooker.UnHook();
		}

		private void BTSetting_Click(object sender, EventArgs e)
		{
			_hooker.UnHook();

			(new settForm()).ShowDialog();

			List<int> list = new List<int>();
			list.Add(_data.intDelete);
			list.Add(_data.intGameMode);
			list.Add(_data.intCorrection);
			_hooker.SetBlockKey(list);
			_hooker.SetHook();
		}

		private void ControllLeftSkillCoolDown(LeftSkillCoolDownClass skill)
		{
			lock (_leftSkillCoolDownLock)
			{
				string player = "";
				string name = "";
				long time = 0;
				bool runAble = false;

				// 화면갱신
				if (skill == null)
				{
					for (int i = 0; i < _leftSkillCoolDown.Count; i++)
					{
						_leftSkillCoolDown[i].GetLeftCoolDown(ref player, ref name, ref time, ref runAble);

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
				skill.GetLeftCoolDown(ref player, ref name, ref time, ref runAble);
				LBCoolDown.Items.Add(name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000));

				// tcp send
				if (_tcPClient.GetConnState() && skill.tcpUsing)
				{
					_tcPClient.Send(skill, "NEW");
				}
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

		private void UpdateKey(object sender, keyboardHooker.KeyboardHookEventArg e)
		{
			// ctrl && space
			if (e._keyCode == 162) Invoke((MethodInvoker)delegate { _ctrlState = e._lParam == (IntPtr)0x100 ? true : false; });
			if (e._keyCode == 32) Invoke((MethodInvoker)delegate { _spaceState = e._lParam == (IntPtr)0x100 ? true : false; });

			// 훅 장금
			if (e._lParam == (IntPtr)0x101 && e._keyCode == _data.intHookPause)
			{
				_hooker.SetHookState(!_hooker.GetHookState());
				LBHookState.Invoke((MethodInvoker)delegate { LBHookState.ForeColor = _hooker.GetHookState() ? Color.Red : Color.Blue; });
			}
			if (_hooker.GetHookState())
			{
				return;
			}



			// 질풍가도
			if (_spaceState && _ctrlState && _data.galeRoadEnable)
			{
				Invoke((MethodInvoker)delegate
				{
					ControllLeftSkillCoolDown(
					new LeftSkillCoolDownClass(
						"",
						false,
						"질풍가도",
						_data.galeRoadCoolDown * 1000,
						_data.galeRoadCoolDown * 1000,
						false, _gameServerState));
				});
				return;
			}

			if (e._lParam == (IntPtr)0x101)
			{
				// 게임모드
				if (e._keyCode == _data.intGameMode)
				{
					Invoke((MethodInvoker)delegate
					{
						if (_gameModeState)
						{
							FormBorderStyle = FormBorderStyle.FixedSingle;
							BTSetting.Visible = true;
							BTClear.Visible = true;
							BTServerConn.Visible = true;
						}
						else
						{
							FormBorderStyle = FormBorderStyle.None;
							BTSetting.Visible = false;
							BTClear.Visible = false;
							BTServerConn.Visible = false;
						}
						_gameModeState = !_gameModeState;
					});
				}
				// 마지막 스킬 삭제
				else if (e._keyCode == _data.intDelete)
				{
					Invoke((MethodInvoker)delegate
					{
						lock (_leftSkillCoolDownLock)
						{
							if (_leftSkillCoolDown.Count > 0)
							{
								// tcp send
								if (_tcPClient.GetConnState() && _leftSkillCoolDown[_leftSkillCoolDown.Count - 1].tcpUsing)
								{
									_tcPClient.Send(_leftSkillCoolDown[_leftSkillCoolDown.Count - 1], "DEL");
								}
								LBCoolDown.Items.RemoveAt(_leftSkillCoolDown.Count - 1);
								_leftSkillCoolDown.RemoveAt(_leftSkillCoolDown.Count - 1);
							}
						}
					});
				}
				// 맵 로딩 보정
				else if (e._keyCode == _data.intCorrection)
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
							if (_data.skillEnable[i] && _data.intSkillBind[i] == e._keyCode)
							{
								ControllLeftSkillCoolDown(
									new LeftSkillCoolDownClass(
										"",
										_data.skillUnique[i],
										_data.skillName[i],
										_data.skillCoolDown[i] * 1000,
										_data.skillDuration[i] * 1000,
										_data.tcpUsing[i],
										_gameServerState));
							}
						}
					});
				}
			}
		}

		private void BTServerConn_Click(object sender, EventArgs e)
		{
			_playerSkill = new OthersPlayerSkill();
			_playerSkill._form1 = this;
			_playerSkill.Show();
		}

		private void UpdateSkill(object sender, TCPClient.ReqeustSkillNewEventArg e)
		{
			Invoke((MethodInvoker)delegate
			{
				if (e._eventType == "STOP")
				{
					ControllLeftSkillCoolDown(
						new LeftSkillCoolDownClass(
							"서버",
							e._unique,
							"게임 서버 랙으로 인한 정지",
							e._coolDown,
							e._duration,
							true,
							_gameServerState));
					_gameServerState = false;
					lock (_leftSkillCoolDownLock)
					{
						foreach (LeftSkillCoolDownClass skill in _leftSkillCoolDown)
						{
							skill.stopwatch.Stop();
							if (skill.stopwatch.ElapsedMilliseconds < skill.duration) skill.duration += 1000;
							else skill.coolDown += 1000;
						}
					}
				}
				else if (e._eventType == "START")
				{
					ControllLeftSkillCoolDown(
						new LeftSkillCoolDownClass(
							e._player,
							e._unique,
							e._name,
							e._coolDown,
							e._duration,
							true,
							_gameServerState));
					_gameServerState = true;
					lock (_leftSkillCoolDownLock)
					{
						foreach (LeftSkillCoolDownClass skill in _leftSkillCoolDown)
						{
							skill.stopwatch.Start();
						}
					}
				}
			});
		}
	}

	class LeftSkillCoolDownClass
	{
		public string player = "";
		public bool unique = false;
		public string name = "";
		public long coolDown = 0;   // ms, 1000ms == 1s
		public long duration = 0;   // ms, 1000ms == 1s
		public bool tcpUsing = false;
		public Stopwatch stopwatch = new Stopwatch();

		private LeftSkillCoolDownClass() { }
		public LeftSkillCoolDownClass(string player, bool unique, string name, long coolDown, long duration, bool tcpUsing, bool state)
		{
			this.player = player;
			this.unique = unique;
			this.name = name;
			this.coolDown = coolDown;
			this.duration = duration;
			this.tcpUsing = tcpUsing;

			stopwatch.Start();

			if (!state) stopwatch.Stop();
		}
		~LeftSkillCoolDownClass()
		{
			stopwatch.Stop();
		}

		private object locker = new object();

		public void GetLeftCoolDown(ref string player, ref string name, ref long time, ref bool runAble)
		{
			lock (locker)
			{
				player = this.player;
				name = this.name;
				if (duration > stopwatch.ElapsedMilliseconds)
				{
					time = duration - stopwatch.ElapsedMilliseconds;
					runAble = true;
					return;
				}
				if (unique)
				{
					time = coolDown + duration - stopwatch.ElapsedMilliseconds;
				}
				else
				{
					time = coolDown - stopwatch.ElapsedMilliseconds;
				}
				runAble = false;
			}
		}
	}
}