using SpecialCampaignSkillCoolDown.Data;
using System;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown.FormFolder
{
	public partial class FormSetting : Form
	{
		public FormSetting()
		{
			InitializeComponent();
		}

		private SetData _data = SetData.GetInstance();
		private ProfileList _profileList = ProfileList.GetInstance();

		private void FormSetting_Load(object sender, EventArgs e)
		{
			BTBindKeyHookPause.Text = _data.stringHookPause;
			BTGameModeBind.Text = _data.stringGameMode;
			BTDelete.Text = _data.stringDelete;
			TBServerIP.Text = _data.ServerIp;
			NUDSERVERPORT.Value = _data.ServerPort;
			TBNICKNAME.Text = _data.playerName;
			foreach (ProfileData data in _profileList._profileList)
			{
				LBPROFILE.Items.Add(data._profileName);
			}
		}

		private void LBPROFILE_SelectedIndexChanged(object sender, EventArgs e)
		{
			LBSKILL.Items.Clear();
			if (LBPROFILE.SelectedIndex != -1)
			{
				NUD특수스킬.Enabled = true;
				NUD특수스킬.Value = _profileList._profileList[LBPROFILE.SelectedIndex]._CoolDown1;
				foreach (ProfileSkillData skill in _profileList._profileList[LBPROFILE.SelectedIndex]._list)
				{
					LBSKILL.Items.Add(skill._name);
				}
			}
		}

		private void BTEXIT_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FormSetting_FormClosed(object sender, FormClosedEventArgs e)
		{
			_profileList.Load();
		}

		private void BTNEW_Click(object sender, EventArgs e)
		{
			using (FormDialogResultText form = new FormDialogResultText())
			{
				var result = form.ShowDialog();
				if (result == DialogResult.OK)
				{
					ProfileData newData = new ProfileData(form.input);
					_profileList._profileList.Add(newData);
					LBPROFILE.Items.Add(form.input);
				}
			}
		}

		private void BTSAVE_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("선택하신 정보가 저장됩니다", "저장", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				_profileList._profileSelect = _profileList._profileList[LBPROFILE.SelectedIndex]._profileName;
				_profileList.Save();
				_data.ServerIp = TBServerIP.Text;
				_data.ServerPort = (int)NUDSERVERPORT.Value;
				_data.playerName = TBNICKNAME.Text;
			}
		}

		private void BTDEL_Click(object sender, EventArgs e)
		{
			_profileList._profileList.RemoveAt(LBPROFILE.SelectedIndex);
			LBPROFILE.Items.RemoveAt(LBPROFILE.SelectedIndex);
		}

		private void BTSkillNew_Click(object sender, EventArgs e)
		{
			if (LBPROFILE.SelectedIndex != -1)
			{
				using (FormDialogResultText form = new FormDialogResultText())
				{
					var result = form.ShowDialog();
					if (result == DialogResult.OK)
					{
						ProfileSkillData skill = new ProfileSkillData(form.input);
						_profileList._profileList[LBPROFILE.SelectedIndex]._list.Add(skill);
						LBSKILL.Items.Add(form.input);
					}
				}
			}
		}

		private void BTSkillDel_Click(object sender, EventArgs e)
		{
			_profileList._profileList[LBPROFILE.SelectedIndex]._list.RemoveAt(LBSKILL.SelectedIndex);
			LBSKILL.Items.RemoveAt(LBSKILL.SelectedIndex);
		}

		private void LBSKILL_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				EquipmentOnOff(true);

				CBEnable.Checked = _profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._enable;
				CBTCPEnable.Checked = _profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._tcpEnable;
				CBType.Checked = _profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._skillType;

				BTBind1.Text = _profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._keyStr;

				NUDDuration.Value = _profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._duration;
				NUDCoolDown.Value = _profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._coolTime;
			}
			else
			{
				EquipmentOnOff(false);

				CBEnable.Checked = false;
				CBTCPEnable.Checked = false;
				CBType.Checked = false;

				BTBind1.Text = "BINDKEY";

				NUDDuration.Value = 0;
				NUDCoolDown.Value = 0;
			}
		}

		private void EquipmentOnOff(bool onoff)
		{
			CBEnable.Enabled = onoff;
			CBTCPEnable.Enabled = onoff;
			CBType.Enabled = onoff;
			BTBind1.Enabled = onoff;
			NUDDuration.Enabled = onoff;
			NUDCoolDown.Enabled = onoff;
		}

		private void CBEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._enable = CBEnable.Checked;
			}
		}

		private void CBTCPEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._tcpEnable = CBTCPEnable.Checked;
			}
		}

		private void CBType_CheckedChanged(object sender, EventArgs e)
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._skillType = CBType.Checked;
			}
		}

		private void BTBind1_KeyUp(object sender, KeyEventArgs e)
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				if (e.KeyValue == 27)
				{
					_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._keyInt = 0;
					_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._keyStr = " ";
					BTBind1.Text = "BINDKEY1";
					return;
				}
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._keyInt = (int)e.KeyCode;
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._keyStr = e.KeyCode.ToString();
				BTBind1.Text = e.KeyCode.ToString();
			}
		}

		private void NUDDurationChange()
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._duration = (long)NUDDuration.Value;
			}
		}

		private void NUDDurationChange(object sender, KeyEventArgs e)
		{
			NUDDurationChange();
		}

		private void NUDDurationChange(object sender, ScrollEventArgs e)
		{
			NUDDurationChange();
		}

		private void NUDDurationChange(object sender, MouseEventArgs e)
		{
			NUDDurationChange();
		}

		private void NUDCoolDownChange()
		{
			if (LBPROFILE.SelectedIndex != -1 && LBSKILL.SelectedIndex != -1)
			{
				_profileList._profileList[LBPROFILE.SelectedIndex]._list[LBSKILL.SelectedIndex]._coolTime = (long)NUDCoolDown.Value;
			}
		}

		private void NUDCoolDownChange(object sender, MouseEventArgs e)
		{
			NUDCoolDownChange();
		}

		private void NUDCoolDown_Scroll(object sender, ScrollEventArgs e)
		{
			NUDCoolDownChange();
		}

		private void NUDCoolDown_KeyUp(object sender, KeyEventArgs e)
		{
			NUDCoolDownChange();
		}

		private void NUD특수스킬Change()
		{
			if (LBPROFILE.SelectedIndex != -1)
			{
				_profileList._profileList[LBPROFILE.SelectedIndex]._CoolDown1 = (int)NUD특수스킬.Value;
			}
		}

		private void NUD특수스킬_Scroll(object sender, ScrollEventArgs e)
		{
			NUD특수스킬Change();
		}

		private void NUD특수스킬_KeyUp(object sender, KeyEventArgs e)
		{
			NUD특수스킬Change();
		}

		private void NUD특수스킬_MouseUp(object sender, MouseEventArgs e)
		{
			NUD특수스킬Change();
		}
	}
}