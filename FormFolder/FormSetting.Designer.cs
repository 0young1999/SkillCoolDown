namespace SpecialCampaignSkillCoolDown.FormFolder
{
	partial class FormSetting
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BTDelete = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.BTGameModeBind = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.BTBindKeyHookPause = new System.Windows.Forms.Button();
			this.LBPROFILE = new System.Windows.Forms.ListBox();
			this.BTEXIT = new System.Windows.Forms.Button();
			this.BTSAVE = new System.Windows.Forms.Button();
			this.BTDEL = new System.Windows.Forms.Button();
			this.BTNEW = new System.Windows.Forms.Button();
			this.LBSKILL = new System.Windows.Forms.ListBox();
			this.BTSkillNew = new System.Windows.Forms.Button();
			this.BTSkillDel = new System.Windows.Forms.Button();
			this.CBEnable = new System.Windows.Forms.CheckBox();
			this.CBTCPEnable = new System.Windows.Forms.CheckBox();
			this.CBType = new System.Windows.Forms.CheckBox();
			this.BTBind1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.NUDDuration = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.NUDCoolDown = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.TBServerIP = new System.Windows.Forms.TextBox();
			this.NUDSERVERPORT = new System.Windows.Forms.NumericUpDown();
			this.TBNICKNAME = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NUD특수스킬 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.NUDDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDCoolDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDSERVERPORT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD특수스킬)).BeginInit();
			this.SuspendLayout();
			// 
			// BTDelete
			// 
			this.BTDelete.Location = new System.Drawing.Point(211, 24);
			this.BTDelete.Name = "BTDelete";
			this.BTDelete.Size = new System.Drawing.Size(75, 23);
			this.BTDelete.TabIndex = 89;
			this.BTDelete.Text = "마지막 스킬 사용 삭제";
			this.BTDelete.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(193, 9);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(125, 12);
			this.label18.TabIndex = 88;
			this.label18.Text = "마지막 스킬 사용 삭제";
			// 
			// BTGameModeBind
			// 
			this.BTGameModeBind.Location = new System.Drawing.Point(107, 24);
			this.BTGameModeBind.Name = "BTGameModeBind";
			this.BTGameModeBind.Size = new System.Drawing.Size(75, 23);
			this.BTGameModeBind.TabIndex = 87;
			this.BTGameModeBind.Text = "게임 모드";
			this.BTGameModeBind.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(117, 9);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(57, 12);
			this.label17.TabIndex = 86;
			this.label17.Text = "게임 모드";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(12, 9);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(85, 12);
			this.label16.TabIndex = 85;
			this.label16.Text = "감지 정지 버튼";
			// 
			// BTBindKeyHookPause
			// 
			this.BTBindKeyHookPause.Location = new System.Drawing.Point(14, 24);
			this.BTBindKeyHookPause.Name = "BTBindKeyHookPause";
			this.BTBindKeyHookPause.Size = new System.Drawing.Size(75, 23);
			this.BTBindKeyHookPause.TabIndex = 84;
			this.BTBindKeyHookPause.Text = "감지 정지";
			this.BTBindKeyHookPause.UseVisualStyleBackColor = true;
			// 
			// LBPROFILE
			// 
			this.LBPROFILE.FormattingEnabled = true;
			this.LBPROFILE.ItemHeight = 12;
			this.LBPROFILE.Location = new System.Drawing.Point(14, 94);
			this.LBPROFILE.Name = "LBPROFILE";
			this.LBPROFILE.Size = new System.Drawing.Size(156, 340);
			this.LBPROFILE.TabIndex = 90;
			this.LBPROFILE.SelectedIndexChanged += new System.EventHandler(this.LBPROFILE_SelectedIndexChanged);
			// 
			// BTEXIT
			// 
			this.BTEXIT.Location = new System.Drawing.Point(701, 12);
			this.BTEXIT.Name = "BTEXIT";
			this.BTEXIT.Size = new System.Drawing.Size(75, 35);
			this.BTEXIT.TabIndex = 91;
			this.BTEXIT.Text = "EXIT";
			this.BTEXIT.UseVisualStyleBackColor = true;
			this.BTEXIT.Click += new System.EventHandler(this.BTEXIT_Click);
			// 
			// BTSAVE
			// 
			this.BTSAVE.Location = new System.Drawing.Point(620, 12);
			this.BTSAVE.Name = "BTSAVE";
			this.BTSAVE.Size = new System.Drawing.Size(75, 35);
			this.BTSAVE.TabIndex = 92;
			this.BTSAVE.Text = "SAVE";
			this.BTSAVE.UseVisualStyleBackColor = true;
			this.BTSAVE.Click += new System.EventHandler(this.BTSAVE_Click);
			// 
			// BTDEL
			// 
			this.BTDEL.Location = new System.Drawing.Point(95, 53);
			this.BTDEL.Name = "BTDEL";
			this.BTDEL.Size = new System.Drawing.Size(75, 35);
			this.BTDEL.TabIndex = 93;
			this.BTDEL.Text = "DEL";
			this.BTDEL.UseVisualStyleBackColor = true;
			this.BTDEL.Click += new System.EventHandler(this.BTDEL_Click);
			// 
			// BTNEW
			// 
			this.BTNEW.Location = new System.Drawing.Point(14, 53);
			this.BTNEW.Name = "BTNEW";
			this.BTNEW.Size = new System.Drawing.Size(75, 35);
			this.BTNEW.TabIndex = 94;
			this.BTNEW.Text = "NEW";
			this.BTNEW.UseVisualStyleBackColor = true;
			this.BTNEW.Click += new System.EventHandler(this.BTNEW_Click);
			// 
			// LBSKILL
			// 
			this.LBSKILL.FormattingEnabled = true;
			this.LBSKILL.ItemHeight = 12;
			this.LBSKILL.Location = new System.Drawing.Point(176, 94);
			this.LBSKILL.Name = "LBSKILL";
			this.LBSKILL.Size = new System.Drawing.Size(208, 340);
			this.LBSKILL.TabIndex = 95;
			this.LBSKILL.SelectedIndexChanged += new System.EventHandler(this.LBSKILL_SelectedIndexChanged);
			// 
			// BTSkillNew
			// 
			this.BTSkillNew.Location = new System.Drawing.Point(194, 53);
			this.BTSkillNew.Name = "BTSkillNew";
			this.BTSkillNew.Size = new System.Drawing.Size(75, 35);
			this.BTSkillNew.TabIndex = 97;
			this.BTSkillNew.Text = "NEW";
			this.BTSkillNew.UseVisualStyleBackColor = true;
			this.BTSkillNew.Click += new System.EventHandler(this.BTSkillNew_Click);
			// 
			// BTSkillDel
			// 
			this.BTSkillDel.Location = new System.Drawing.Point(275, 53);
			this.BTSkillDel.Name = "BTSkillDel";
			this.BTSkillDel.Size = new System.Drawing.Size(75, 35);
			this.BTSkillDel.TabIndex = 96;
			this.BTSkillDel.Text = "DEL";
			this.BTSkillDel.UseVisualStyleBackColor = true;
			this.BTSkillDel.Click += new System.EventHandler(this.BTSkillDel_Click);
			// 
			// CBEnable
			// 
			this.CBEnable.AutoSize = true;
			this.CBEnable.Enabled = false;
			this.CBEnable.Location = new System.Drawing.Point(390, 94);
			this.CBEnable.Name = "CBEnable";
			this.CBEnable.Size = new System.Drawing.Size(60, 16);
			this.CBEnable.TabIndex = 98;
			this.CBEnable.Text = "활성화";
			this.CBEnable.UseVisualStyleBackColor = true;
			this.CBEnable.CheckedChanged += new System.EventHandler(this.CBEnable_CheckedChanged);
			// 
			// CBTCPEnable
			// 
			this.CBTCPEnable.AutoSize = true;
			this.CBTCPEnable.Enabled = false;
			this.CBTCPEnable.Location = new System.Drawing.Point(456, 94);
			this.CBTCPEnable.Name = "CBTCPEnable";
			this.CBTCPEnable.Size = new System.Drawing.Size(76, 16);
			this.CBTCPEnable.TabIndex = 99;
			this.CBTCPEnable.Text = "서버 연결";
			this.CBTCPEnable.UseVisualStyleBackColor = true;
			this.CBTCPEnable.CheckedChanged += new System.EventHandler(this.CBTCPEnable_CheckedChanged);
			// 
			// CBType
			// 
			this.CBType.AutoSize = true;
			this.CBType.Enabled = false;
			this.CBType.Location = new System.Drawing.Point(539, 94);
			this.CBType.Name = "CBType";
			this.CBType.Size = new System.Drawing.Size(140, 16);
			this.CBType.TabIndex = 100;
			this.CBType.Text = "지속시간 쿨타임 포함";
			this.CBType.UseVisualStyleBackColor = true;
			this.CBType.CheckedChanged += new System.EventHandler(this.CBType_CheckedChanged);
			// 
			// BTBind1
			// 
			this.BTBind1.Enabled = false;
			this.BTBind1.Location = new System.Drawing.Point(467, 119);
			this.BTBind1.Name = "BTBind1";
			this.BTBind1.Size = new System.Drawing.Size(75, 23);
			this.BTBind1.TabIndex = 101;
			this.BTBind1.Text = "BINDKEY";
			this.BTBind1.UseVisualStyleBackColor = true;
			this.BTBind1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BTBind1_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(390, 124);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 12);
			this.label1.TabIndex = 103;
			this.label1.Text = "BIND KEY";
			// 
			// NUDDuration
			// 
			this.NUDDuration.Enabled = false;
			this.NUDDuration.Location = new System.Drawing.Point(481, 150);
			this.NUDDuration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.NUDDuration.Name = "NUDDuration";
			this.NUDDuration.Size = new System.Drawing.Size(120, 21);
			this.NUDDuration.TabIndex = 106;
			this.NUDDuration.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NUDDurationChange);
			this.NUDDuration.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NUDDurationChange);
			this.NUDDuration.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NUDDurationChange);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(390, 155);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 12);
			this.label4.TabIndex = 107;
			this.label4.Text = "스킬 작동 시간";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(396, 182);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 12);
			this.label5.TabIndex = 108;
			this.label5.Text = "스킬 쿨 타임";
			// 
			// NUDCoolDown
			// 
			this.NUDCoolDown.Enabled = false;
			this.NUDCoolDown.Location = new System.Drawing.Point(481, 177);
			this.NUDCoolDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.NUDCoolDown.Name = "NUDCoolDown";
			this.NUDCoolDown.Size = new System.Drawing.Size(120, 21);
			this.NUDCoolDown.TabIndex = 109;
			this.NUDCoolDown.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NUDCoolDown_Scroll);
			this.NUDCoolDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NUDCoolDown_KeyUp);
			this.NUDCoolDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NUDCoolDownChange);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(325, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 110;
			this.label6.Text = "서버주소";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(408, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 111;
			this.label7.Text = "서버포트";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(491, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 12);
			this.label8.TabIndex = 112;
			this.label8.Text = "닉네임";
			// 
			// TBServerIP
			// 
			this.TBServerIP.Location = new System.Drawing.Point(303, 26);
			this.TBServerIP.Name = "TBServerIP";
			this.TBServerIP.Size = new System.Drawing.Size(100, 21);
			this.TBServerIP.TabIndex = 113;
			// 
			// NUDSERVERPORT
			// 
			this.NUDSERVERPORT.Location = new System.Drawing.Point(409, 26);
			this.NUDSERVERPORT.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.NUDSERVERPORT.Name = "NUDSERVERPORT";
			this.NUDSERVERPORT.Size = new System.Drawing.Size(52, 21);
			this.NUDSERVERPORT.TabIndex = 114;
			this.NUDSERVERPORT.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
			// 
			// TBNICKNAME
			// 
			this.TBNICKNAME.Location = new System.Drawing.Point(467, 25);
			this.TBNICKNAME.Name = "TBNICKNAME";
			this.TBNICKNAME.Size = new System.Drawing.Size(100, 21);
			this.TBNICKNAME.TabIndex = 115;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(548, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 12);
			this.label3.TabIndex = 105;
			this.label3.Text = "ESC 클릭시 바인드 해제";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(404, 414);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(165, 12);
			this.label2.TabIndex = 116;
			this.label2.Text = "특수 스킬(컨트롤 + 스페이스)";
			// 
			// NUD특수스킬
			// 
			this.NUD특수스킬.Enabled = false;
			this.NUD특수스킬.Location = new System.Drawing.Point(575, 408);
			this.NUD특수스킬.Name = "NUD특수스킬";
			this.NUD특수스킬.Size = new System.Drawing.Size(120, 21);
			this.NUD특수스킬.TabIndex = 117;
			this.NUD특수스킬.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NUD특수스킬_Scroll);
			this.NUD특수스킬.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NUD특수스킬_KeyUp);
			this.NUD특수스킬.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NUD특수스킬_MouseUp);
			// 
			// FormSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(780, 441);
			this.ControlBox = false;
			this.Controls.Add(this.NUD특수스킬);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TBNICKNAME);
			this.Controls.Add(this.NUDSERVERPORT);
			this.Controls.Add(this.TBServerIP);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.NUDCoolDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.NUDDuration);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BTBind1);
			this.Controls.Add(this.CBType);
			this.Controls.Add(this.CBTCPEnable);
			this.Controls.Add(this.CBEnable);
			this.Controls.Add(this.BTSkillNew);
			this.Controls.Add(this.BTSkillDel);
			this.Controls.Add(this.LBSKILL);
			this.Controls.Add(this.BTNEW);
			this.Controls.Add(this.BTDEL);
			this.Controls.Add(this.BTSAVE);
			this.Controls.Add(this.BTEXIT);
			this.Controls.Add(this.LBPROFILE);
			this.Controls.Add(this.BTDelete);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.BTGameModeBind);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.BTBindKeyHookPause);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSetting";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "설정";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSetting_FormClosed);
			this.Load += new System.EventHandler(this.FormSetting_Load);
			((System.ComponentModel.ISupportInitialize)(this.NUDDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDCoolDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDSERVERPORT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUD특수스킬)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BTDelete;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button BTGameModeBind;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button BTBindKeyHookPause;
		private System.Windows.Forms.ListBox LBPROFILE;
		private System.Windows.Forms.Button BTEXIT;
		private System.Windows.Forms.Button BTSAVE;
		private System.Windows.Forms.Button BTDEL;
		private System.Windows.Forms.Button BTNEW;
		private System.Windows.Forms.ListBox LBSKILL;
		private System.Windows.Forms.Button BTSkillNew;
		private System.Windows.Forms.Button BTSkillDel;
		private System.Windows.Forms.CheckBox CBEnable;
		private System.Windows.Forms.CheckBox CBTCPEnable;
		private System.Windows.Forms.CheckBox CBType;
		private System.Windows.Forms.Button BTBind1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NUDDuration;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown NUDCoolDown;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox TBServerIP;
		private System.Windows.Forms.NumericUpDown NUDSERVERPORT;
		private System.Windows.Forms.TextBox TBNICKNAME;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown NUD특수스킬;
	}
}