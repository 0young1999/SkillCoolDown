using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown
{
	public partial class OthersPlayerSkill : Form
	{
		public OthersPlayerSkill()
		{
			InitializeComponent();
		}

		public Form1 _form1;

		private static TCPClient _tcp = TCPClient.GetInstance();

		private static keyboardHooker _hooker = keyboardHooker.GetKeyboardHooker();

		private SetData _data = SetData.GetInstance();

		// 쿨타임 돌고 있는 스킬들
		private static List<LeftSkillCoolDownClass> _leftSkillCoolDownOther = new List<LeftSkillCoolDownClass>();
		private object _leftSkillCoolDownLockOther = new object();

		private bool _gameModeState = false;

		// 게임 서버 상태
		private bool _gameServerState = true;

		private void OthersPlayerSkill_Load(object sender, EventArgs e)
		{
			keyboardHooker.UpdataKeyboardHookEvent += new EventHandler<keyboardHooker.KeyboardHookEventArg>(UpdateKey);
			TCPClient._ReqeustSkillNewEvent += new EventHandler<TCPClient.ReqeustSkillNewEventArg>(UpdateSkill);
			_form1.Invoke((MethodInvoker)delegate { _form1.BTServerConn.Enabled = false; });
			_gameModeState = _form1.GetGameModeState();
			_tcp.Open();
		}

		private void UpdateKey(object sender, keyboardHooker.KeyboardHookEventArg e)
		{
			if (_hooker.GetHookState())
			{
				return;
			}

			// 게임모드
			if (e._lParam == (IntPtr)0x101 && e._keyCode == _data.intGameMode)
			{
				Invoke((MethodInvoker)delegate
				{
					if (_gameModeState)
					{
						FormBorderStyle = FormBorderStyle.FixedSingle;
					}
					else
					{
						FormBorderStyle = FormBorderStyle.None;
					}
					_gameModeState = !_gameModeState;
				});
			}
			// 맵 로딩 보정
			//else if (e._lParam == (IntPtr)0x101 && e._keyCode == _data.intCorrection)
			//{
			//	Invoke((MethodInvoker)delegate
			//	{
			//		lock (_leftSkillCoolDownLockOther)
			//		{
			//			for (int i = 0; i < _leftSkillCoolDownOther.Count; i++)
			//				_leftSkillCoolDownOther[i].coolDown += 20000;
			//		}
			//	});
			//}
		}

		private void ControllLeftSkillCoolDown(LeftSkillCoolDownClass skill)
		{
			lock (_leftSkillCoolDownLockOther)
			{
				if (_tcp.GetConnState() == false)
				{
					Close();
				}
				string player = "";
				string name = "";
				long time = 0;
				bool runAble = false;

				// 화면갱신
				if (skill == null)
				{
					for (int i = 0; i < _leftSkillCoolDownOther.Count; i++)
					{
						_leftSkillCoolDownOther[i].GetLeftCoolDown(ref player, ref name, ref time, ref runAble);

						if (runAble)
						{
							LBOthersCoolDown.Items[i] = (player.Length > 7 ? player.Substring(0, 7) : player) + " : " + name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000);
							continue;
						}

						if (time < 0)
						{
							_leftSkillCoolDownOther.Remove(_leftSkillCoolDownOther[i]);
							LBOthersCoolDown.Items.RemoveAt(i);
							continue;
						}

						LBOthersCoolDown.Items[i] = (player.Length > 7 ? player.Substring(0, 7) : player) + " : " + name + " : " + string.Format("{0:0.0}", (float)time / 1000);
					}
					return;
				}

				// 스킬 쿨 추가 중복 방지
				if (skill.player == _data.playerName) { return; }
				if (skill.player != "서버")
				{
					for (int i = 0; i < _leftSkillCoolDownOther.Count; i++)
					{
						if (skill.name == _leftSkillCoolDownOther[i].name && skill.player == _leftSkillCoolDownOther[i].player) { return; }
					}
				}
				_leftSkillCoolDownOther.Add(skill);
				skill.GetLeftCoolDown(ref player, ref name, ref time, ref runAble);
				LBOthersCoolDown.Items.Add((player.Length > 7 ? player.Substring(0, 7) : player) + " : " + name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000));
			}
		}

		private void UpdateSkill(object sender, TCPClient.ReqeustSkillNewEventArg e)
		{
			Invoke((MethodInvoker)delegate
			{
				if (e._eventType == "NEW") ControllLeftSkillCoolDown(new LeftSkillCoolDownClass(e._player, e._unique, e._name, e._coolDown, e._duration, true, _gameServerState));
				else if (e._eventType == "DEL")
				{
					lock (_leftSkillCoolDownLockOther)
					{
						for (int i = 0; i < _leftSkillCoolDownOther.Count; i++)
						{
							if (_leftSkillCoolDownOther[i].player == e._player && _leftSkillCoolDownOther[i].name == e._name)
							{
								LBOthersCoolDown.Items.RemoveAt(i);
								_leftSkillCoolDownOther.RemoveAt(i);
								return;
							}
						}
					}
				}
				else if (e._eventType == "STOP")
				{
					ControllLeftSkillCoolDown(
						new LeftSkillCoolDownClass(
							e._player,
							e._unique,
							e._name,
							e._coolDown,
							e._duration,
							false,
							_gameServerState));
					_gameServerState = false;
					lock (_leftSkillCoolDownLockOther)
					{
						foreach (LeftSkillCoolDownClass skill in _leftSkillCoolDownOther)
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
							false,
							_gameServerState));
					_gameServerState = true;
					lock (_leftSkillCoolDownLockOther)
					{
						foreach (LeftSkillCoolDownClass skill in _leftSkillCoolDownOther)
						{
							skill.stopwatch.Start();
						}
					}
				}
				else
				{
					ControllLeftSkillCoolDown(new LeftSkillCoolDownClass("서버", false, "알수없는 수신", 5000, 5000, true, _gameServerState));
				}
			});
		}

		private void TimerSkillCoolDown_Tick(object sender, EventArgs e)
		{
			ControllLeftSkillCoolDown(null);
		}

		private void OthersPlayerSkill_FormClosing(object sender, FormClosingEventArgs e)
		{
			TimerSkillCoolDown.Enabled = false;
		}
	}
}