namespace SpecialCampaignSkillCoolDown
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.BTGameMode = new System.Windows.Forms.Button();
			this.BTSetting = new System.Windows.Forms.Button();
			this.TimerSkillCoolDown = new System.Windows.Forms.Timer(this.components);
			this.LBCoolDown = new System.Windows.Forms.ListBox();
			this.InPutKeyControll = new System.Windows.Forms.Timer(this.components);
			this.BTClear = new System.Windows.Forms.Button();
			this.LBHookState = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BTGameMode
			// 
			this.BTGameMode.Location = new System.Drawing.Point(12, 12);
			this.BTGameMode.Name = "BTGameMode";
			this.BTGameMode.Size = new System.Drawing.Size(75, 23);
			this.BTGameMode.TabIndex = 1;
			this.BTGameMode.Text = "게임 모드";
			this.BTGameMode.UseVisualStyleBackColor = true;
			this.BTGameMode.Click += new System.EventHandler(this.BTGameMode_Click);
			// 
			// BTSetting
			// 
			this.BTSetting.Location = new System.Drawing.Point(12, 42);
			this.BTSetting.Name = "BTSetting";
			this.BTSetting.Size = new System.Drawing.Size(75, 23);
			this.BTSetting.TabIndex = 2;
			this.BTSetting.Text = "설정";
			this.BTSetting.UseVisualStyleBackColor = true;
			this.BTSetting.Click += new System.EventHandler(this.BTSetting_Click);
			// 
			// TimerSkillCoolDown
			// 
			this.TimerSkillCoolDown.Enabled = true;
			this.TimerSkillCoolDown.Tick += new System.EventHandler(this.TimerSkillCoolDown_Tick);
			// 
			// LBCoolDown
			// 
			this.LBCoolDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LBCoolDown.CausesValidation = false;
			this.LBCoolDown.Enabled = false;
			this.LBCoolDown.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
			this.LBCoolDown.ForeColor = System.Drawing.Color.Red;
			this.LBCoolDown.FormattingEnabled = true;
			this.LBCoolDown.ItemHeight = 40;
			this.LBCoolDown.Location = new System.Drawing.Point(93, 56);
			this.LBCoolDown.Name = "LBCoolDown";
			this.LBCoolDown.Size = new System.Drawing.Size(594, 400);
			this.LBCoolDown.TabIndex = 3;
			this.LBCoolDown.UseWaitCursor = true;
			// 
			// InPutKeyControll
			// 
			this.InPutKeyControll.Interval = 5;
			this.InPutKeyControll.Tick += new System.EventHandler(this.InPutKeyControll_Tick);
			// 
			// BTClear
			// 
			this.BTClear.Location = new System.Drawing.Point(13, 72);
			this.BTClear.Name = "BTClear";
			this.BTClear.Size = new System.Drawing.Size(75, 23);
			this.BTClear.TabIndex = 4;
			this.BTClear.Text = "초기화";
			this.BTClear.UseVisualStyleBackColor = true;
			this.BTClear.Click += new System.EventHandler(this.BTClear_Click);
			// 
			// LBHookState
			// 
			this.LBHookState.AutoSize = true;
			this.LBHookState.BackColor = System.Drawing.Color.Transparent;
			this.LBHookState.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LBHookState.ForeColor = System.Drawing.Color.Blue;
			this.LBHookState.Location = new System.Drawing.Point(94, 13);
			this.LBHookState.Name = "LBHookState";
			this.LBHookState.Size = new System.Drawing.Size(323, 40);
			this.LBHookState.TabIndex = 5;
			this.LBHookState.Text = "Skill Cool Down";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(699, 468);
			this.Controls.Add(this.LBHookState);
			this.Controls.Add(this.BTClear);
			this.Controls.Add(this.LBCoolDown);
			this.Controls.Add(this.BTSetting);
			this.Controls.Add(this.BTGameMode);
			this.Font = new System.Drawing.Font("굴림", 9F);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "SkillCoolDown";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button BTGameMode;
		private System.Windows.Forms.Button BTSetting;
		private System.Windows.Forms.Timer TimerSkillCoolDown;
		private System.Windows.Forms.ListBox LBCoolDown;
		private System.Windows.Forms.Timer InPutKeyControll;
		private System.Windows.Forms.Button BTClear;
		private System.Windows.Forms.Label LBHookState;
	}
}

