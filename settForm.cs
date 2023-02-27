﻿using System;
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
			for (int i = 0; i < 10; i++)
			{
				data.skillEnable[i] = ((CheckBox)Controls.Find("CBEnable" + i, true).First()).Checked;
				data.skillName[i] = ((TextBox)Controls.Find("TBSkillName" + i, true).First()).Text;
				data.skillCoolDown[i] = (long)((NumericUpDown)Controls.Find("NUDSkillCoolDown" + i, true).First()).Value;
				data.skillDuration[i] = (long)((NumericUpDown)Controls.Find("NUDSkillDuration" + i, true).First()).Value;
				data.skillUnique[i] = ((CheckBox)Controls.Find("CBUniqueSkill" + i, true).First()).Checked;
			}

			data.SaveSettingData();
		}

		private void BTExit_Click(object sender, EventArgs e)
		{
			data.ReadSettingData();
			Close();
		}

		private void settting_Load(object sender, EventArgs e)
		{
			for(int i = 0; i < 10; i++)
			{
				((CheckBox)Controls.Find("CBEnable" + i, true).First()).Checked = data.skillEnable[i];
				((Label)Controls.Find("label" + i, true).First()).Text = data.stringSkillBInd[i];
				((TextBox)Controls.Find("TBSkillName" + i, true).First()).Text = data.skillName[i];
				((NumericUpDown)Controls.Find("NUDSkillCoolDown" + i, true).First()).Value = data.skillCoolDown[i];
				((NumericUpDown)Controls.Find("NUDSkillDuration" + i, true).First()).Value = data.skillDuration[i];
				((CheckBox)Controls.Find("CBUniqueSkill" + i, true).First()).Checked = data.skillUnique[i];
			}

			BTBindKeyHookPause.Text = data.stringHookPause;
			BTGameModeBind.Text = data.stringGameMode;
			BTDelete.Text = data.stringDelete;

			//((NumericUpDown)this.Controls.Find("NUDSkillCoolDown9", true).First()).Value = 300;
		}

		private void KeyBind(int number, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
			{
				return;
			}

			data.intSkillBind[number] = e.KeyValue;
			data.stringSkillBInd[number] = e.KeyCode.ToString();

			((Label)Controls.Find("label" + number, true).First()).Text = e.KeyCode.ToString();
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

		private void settForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			data.ReadSettingData();
		}

		private void BTGameModeBind_KeyUp(object sender, KeyEventArgs e)
		{
			data.intGameMode = e.KeyValue;
			data.stringGameMode = e.KeyCode.ToString();
			BTGameModeBind.Text = e.KeyCode.ToString();
		}

		private void BTDelete_KeyUp(object sender, KeyEventArgs e)
		{
			data.intDelete = e.KeyValue;
			data.stringDelete = e.KeyCode.ToString();
			BTDelete.Text = e.KeyCode.ToString();
		}
	}
}
