using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown
{
	public partial class settForm : Form
	{
		private SetData data = SetData.GetInstance();

		public settForm()
		{
			InitializeComponent();
		}

		private void BTSave_Click(object sender, EventArgs e)
		{
			data.skillEnable[0] = CBEnable0.Checked;
			data.skillEnable[1] = CBEnable1.Checked;
			data.skillEnable[2] = CBEnable2.Checked;
			data.skillEnable[3] = CBEnable3.Checked;
			data.skillEnable[4] = CBEnable4.Checked;
			data.skillEnable[5] = CBEnable5.Checked;
			data.skillEnable[6] = CBEnable6.Checked;
			data.skillEnable[7] = CBEnable7.Checked;
			data.skillEnable[8] = CBEnable8.Checked;
			data.skillEnable[9] = CBEnable9.Checked;

			//data.stringSkillBInd[0] = label0.Text;
			//data.stringSkillBInd[1] = label1.Text;
			//data.stringSkillBInd[2] = label2.Text;
			//data.stringSkillBInd[3] = label3.Text;
			//data.stringSkillBInd[4] = label4.Text;
			//data.stringSkillBInd[5] = label5.Text;
			//data.stringSkillBInd[6] = label6.Text;
			//data.stringSkillBInd[7] = label7.Text;
			//data.stringSkillBInd[8] = label8.Text;
			//data.stringSkillBInd[9] = label9.Text;

			data.skillName[0] = TBSkillName0.Text;
			data.skillName[1] = TBSkillName1.Text;
			data.skillName[2] = TBSkillName2.Text;
			data.skillName[3] = TBSkillName3.Text;
			data.skillName[4] = TBSkillName4.Text;
			data.skillName[5] = TBSkillName5.Text;
			data.skillName[6] = TBSkillName6.Text;
			data.skillName[7] = TBSkillName7.Text;
			data.skillName[8] = TBSkillName8.Text;
			data.skillName[9] = TBSkillName9.Text;

			data.skillCoolDown[0] = (long)NUDSkillCoolDown0.Value;
			data.skillCoolDown[1] = (long)NUDSkillCoolDown1.Value;
			data.skillCoolDown[2] = (long)NUDSkillCoolDown2.Value;
			data.skillCoolDown[3] = (long)NUDSkillCoolDown3.Value;
			data.skillCoolDown[4] = (long)NUDSkillCoolDown4.Value;
			data.skillCoolDown[5] = (long)NUDSkillCoolDown5.Value;
			data.skillCoolDown[6] = (long)NUDSkillCoolDown6.Value;
			data.skillCoolDown[7] = (long)NUDSkillCoolDown7.Value;
			data.skillCoolDown[8] = (long)NUDSkillCoolDown8.Value;
			data.skillCoolDown[9] = (long)NUDSkillCoolDown9.Value;

			data.skillDuration[0] = (long)NUDSkillDuration0.Value;
			data.skillDuration[1] = (long)NUDSkillDuration1.Value;
			data.skillDuration[2] = (long)NUDSkillDuration2.Value;
			data.skillDuration[3] = (long)NUDSkillDuration3.Value;
			data.skillDuration[4] = (long)NUDSkillDuration4.Value;
			data.skillDuration[5] = (long)NUDSkillDuration5.Value;
			data.skillDuration[6] = (long)NUDSkillDuration6.Value;
			data.skillDuration[7] = (long)NUDSkillDuration7.Value;
			data.skillDuration[8] = (long)NUDSkillDuration8.Value;
			data.skillDuration[9] = (long)NUDSkillDuration9.Value;

			data.skillUnique[0] = CBUniqueSkill0.Checked;
			data.skillUnique[1] = CBUniqueSkill1.Checked;
			data.skillUnique[2] = CBUniqueSkill2.Checked;
			data.skillUnique[3] = CBUniqueSkill3.Checked;
			data.skillUnique[4] = CBUniqueSkill4.Checked;
			data.skillUnique[5] = CBUniqueSkill5.Checked;
			data.skillUnique[6] = CBUniqueSkill6.Checked;
			data.skillUnique[7] = CBUniqueSkill7.Checked;
			data.skillUnique[8] = CBUniqueSkill8.Checked;
			data.skillUnique[9] = CBUniqueSkill9.Checked;

			data.SaveSettingData();
		}

		private void BTExit_Click(object sender, EventArgs e)
		{
			data.ReadSettingData();
			Close();
		}

		private void settting_Load(object sender, EventArgs e)
		{
			CBEnable0.Checked = data.skillEnable[0];
			CBEnable1.Checked = data.skillEnable[1];
			CBEnable2.Checked = data.skillEnable[2];
			CBEnable3.Checked = data.skillEnable[3];
			CBEnable4.Checked = data.skillEnable[4];
			CBEnable5.Checked = data.skillEnable[5];
			CBEnable6.Checked = data.skillEnable[6];
			CBEnable7.Checked = data.skillEnable[7];
			CBEnable8.Checked = data.skillEnable[8];
			CBEnable9.Checked = data.skillEnable[9];

			label0.Text = data.stringSkillBInd[0];
			label1.Text = data.stringSkillBInd[1];
			label2.Text = data.stringSkillBInd[2];
			label3.Text = data.stringSkillBInd[3];
			label4.Text = data.stringSkillBInd[4];
			label5.Text = data.stringSkillBInd[5];
			label6.Text = data.stringSkillBInd[6];
			label7.Text = data.stringSkillBInd[7];
			label8.Text = data.stringSkillBInd[8];
			label9.Text = data.stringSkillBInd[9];

			TBSkillName0.Text = data.skillName[0];
			TBSkillName1.Text = data.skillName[1];
			TBSkillName2.Text = data.skillName[2];
			TBSkillName3.Text = data.skillName[3];
			TBSkillName4.Text = data.skillName[4];
			TBSkillName5.Text = data.skillName[5];
			TBSkillName6.Text = data.skillName[6];
			TBSkillName7.Text = data.skillName[7];
			TBSkillName8.Text = data.skillName[8];
			TBSkillName9.Text = data.skillName[9];

			NUDSkillCoolDown0.Value = data.skillCoolDown[0];
			NUDSkillCoolDown1.Value = data.skillCoolDown[1];
			NUDSkillCoolDown2.Value = data.skillCoolDown[2];
			NUDSkillCoolDown3.Value = data.skillCoolDown[3];
			NUDSkillCoolDown4.Value = data.skillCoolDown[4];
			NUDSkillCoolDown5.Value = data.skillCoolDown[5];
			NUDSkillCoolDown6.Value = data.skillCoolDown[6];
			NUDSkillCoolDown7.Value = data.skillCoolDown[7];
			NUDSkillCoolDown8.Value = data.skillCoolDown[8];
			NUDSkillCoolDown9.Value = data.skillCoolDown[9];
			
			NUDSkillDuration0.Value = data.skillDuration[0];
			NUDSkillDuration1.Value = data.skillDuration[1];
			NUDSkillDuration2.Value = data.skillDuration[2];
			NUDSkillDuration3.Value = data.skillDuration[3];
			NUDSkillDuration4.Value = data.skillDuration[4];
			NUDSkillDuration5.Value = data.skillDuration[5];
			NUDSkillDuration6.Value = data.skillDuration[6];
			NUDSkillDuration7.Value = data.skillDuration[7];
			NUDSkillDuration8.Value = data.skillDuration[8];
			NUDSkillDuration9.Value = data.skillDuration[9];

			CBUniqueSkill0.Checked = data.skillUnique[0];
			CBUniqueSkill1.Checked = data.skillUnique[1];
			CBUniqueSkill2.Checked = data.skillUnique[2];
			CBUniqueSkill3.Checked = data.skillUnique[3];
			CBUniqueSkill4.Checked = data.skillUnique[4];
			CBUniqueSkill5.Checked = data.skillUnique[5];
			CBUniqueSkill6.Checked = data.skillUnique[6];
			CBUniqueSkill7.Checked = data.skillUnique[7];
			CBUniqueSkill8.Checked = data.skillUnique[8];
			CBUniqueSkill9.Checked = data.skillUnique[9];

			BTBindKeyHookPause.Text = data.stringHookPause;
		}

		private void KeyBind(int number, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
			{
				return;
			}

			data.intSkillBind[number] = e.KeyValue;
			data.stringSkillBInd[number] = e.KeyCode.ToString();

			switch(number)
			{
				case 0:
					label0.Text = e.KeyCode.ToString();
					break;
				case 1:
					label1.Text = e.KeyCode.ToString();
					break;
				case 2:
					label2.Text = e.KeyCode.ToString();
					break;
				case 3:
					label3.Text = e.KeyCode.ToString();
					break;
				case 4:
					label4.Text = e.KeyCode.ToString();
					break;
				case 5:
					label5.Text = e.KeyCode.ToString();
					break;
				case 6:
					label6.Text = e.KeyCode.ToString();
					break;
				case 7:
					label7.Text = e.KeyCode.ToString();
					break;
				case 8:
					label8.Text = e.KeyCode.ToString();
					break;
				case 9:
					label9.Text = e.KeyCode.ToString();
					break;
			}
		}

		private void BTBind0_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(0, e);
		}

		private void BTBind1_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(1, e);
		}

		private void BTBind2_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(2, e);
		}

		private void BTBind3_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(3, e);
		}

		private void BTBind4_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(4, e);
		}

		private void BTBind5_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(5, e);
		}

		private void BTBind6_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(6, e);
		}

		private void BTBind7_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(7, e);
		}

		private void BTBind8_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(8, e);
		}

		private void BTBind9_KeyUp(object sender, KeyEventArgs e)
		{
			KeyBind(9, e);
		}

		private void BTBindKeyHookPause_KeyUp(object sender, KeyEventArgs e)
		{
			data.intHookPause = e.KeyValue;
			data.stringHookPause = e.KeyCode.ToString();
			BTBindKeyHookPause.Text = e.KeyCode.ToString();
		}
	}
}
