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
		private static List<LeftSkillCoolDownClass> _leftSkillCoolDown = new List<LeftSkillCoolDownClass>();
		private object _leftSkillCoolDownLock = new object();

		private bool _gameModeState = false;

		private void OthersPlayerSkill_FormClosed(object sender, FormClosedEventArgs e)
		{
			_form1.Invoke((MethodInvoker)delegate { _form1.BTServerConn.Enabled = true; });
		}

		private void OthersPlayerSkill_Load(object sender, EventArgs e)
		{
			keyboardHooker.UpdataKeyboardHookEvent += new EventHandler<keyboardHooker.KeyboardHookEventArg>(UpdateKey);
			TCPClient._ReqeustSkillNewEvent += new EventHandler<TCPClient.ReqeustSkillNewEventArg>(UpdateSkill);
			_form1.Invoke((MethodInvoker)delegate { _form1.BTServerConn.Enabled = false; });
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
			else if (e._lParam == (IntPtr)0x101 && e._keyCode == _data.intCorrection)
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
		}

		private void ControllLeftSkillCoolDown(LeftSkillCoolDownClass skill)
		{
			lock (_leftSkillCoolDownLock)
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
					for (int i = 0; i < _leftSkillCoolDown.Count; i++)
					{
						_leftSkillCoolDown[i].GetLeftCoolDown(ref player, ref name, ref time, ref runAble);

						if (runAble)
						{
							LBOthersCoolDown.Items[i] = (player.Length > 7 ? player.Substring(0, 7) : player) + " : " + name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000);
							continue;
						}

						if (time < 0)
						{
							_leftSkillCoolDown.Remove(_leftSkillCoolDown[i]);
							LBOthersCoolDown.Items.RemoveAt(i);
							continue;
						}

						LBOthersCoolDown.Items[i] = (player.Length > 7 ? player.Substring(0, 7) : player) + " : " + name + " : " + string.Format("{0:0.0}", (float)time / 1000);
					}
					return;
				}

				// 스킬 쿨 추가 중복 방지
				if (skill.player == _data.playerName) { return; }
				for (int i = 0; i < _leftSkillCoolDown.Count; i++)
				{
					if (skill.name == _leftSkillCoolDown[i].name && skill.player == _leftSkillCoolDown[i].player) { return; }
				}
				_leftSkillCoolDown.Add(skill);
				skill.GetLeftCoolDown(ref player, ref name, ref time, ref runAble);
				LBOthersCoolDown.Items.Add((player.Length > 7 ? player.Substring(0, 7) : player) + " : " + name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000));
			}
		}

		private void UpdateSkill(object sender, TCPClient.ReqeustSkillNewEventArg e)
		{
			Invoke((MethodInvoker)delegate
			{
				if (e._eventType == "NEW") ControllLeftSkillCoolDown(new LeftSkillCoolDownClass(e._player, e._unique, e._name, e._coolDown, e._duration, true));
				else if (e._eventType == "DEL")
				{
					lock (_leftSkillCoolDownLock)
					{
						if (_leftSkillCoolDown.Count > 0)
						{
							LBOthersCoolDown.Items.RemoveAt(_leftSkillCoolDown.Count - 1);
							_leftSkillCoolDown.RemoveAt(_leftSkillCoolDown.Count - 1);
						}
						for (int i = 0; i < _leftSkillCoolDown.Count; i++)
						{
							if (_leftSkillCoolDown[i].player == e._player && _leftSkillCoolDown[i].name == e._name)
							{
								LBOthersCoolDown.Items.RemoveAt(i);
								_leftSkillCoolDown.RemoveAt(i);
								return;
							}
						}
					}
				}
				else
				{
					ControllLeftSkillCoolDown(new LeftSkillCoolDownClass("서버 메세지", false, "알수없는 수신", 5000, 5000, true));
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