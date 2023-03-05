namespace SpecialCampaignSkillCoolDown
{
	partial class OthersPlayerSkill
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.LBOthersCoolDown = new System.Windows.Forms.ListBox();
			this.TimerSkillCoolDown = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(266, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "OthersPlayer";
			// 
			// LBOthersCoolDown
			// 
			this.LBOthersCoolDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LBOthersCoolDown.CausesValidation = false;
			this.LBOthersCoolDown.Enabled = false;
			this.LBOthersCoolDown.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LBOthersCoolDown.FormattingEnabled = true;
			this.LBOthersCoolDown.ItemHeight = 40;
			this.LBOthersCoolDown.Location = new System.Drawing.Point(12, 52);
			this.LBOthersCoolDown.Name = "LBOthersCoolDown";
			this.LBOthersCoolDown.Size = new System.Drawing.Size(869, 600);
			this.LBOthersCoolDown.TabIndex = 1;
			this.LBOthersCoolDown.UseWaitCursor = true;
			// 
			// TimerSkillCoolDown
			// 
			this.TimerSkillCoolDown.Enabled = true;
			this.TimerSkillCoolDown.Tick += new System.EventHandler(this.TimerSkillCoolDown_Tick);
			// 
			// OthersPlayerSkill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(893, 658);
			this.Controls.Add(this.LBOthersCoolDown);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OthersPlayerSkill";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Others";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OthersPlayerSkill_FormClosing);
			this.Load += new System.EventHandler(this.OthersPlayerSkill_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox LBOthersCoolDown;
		private System.Windows.Forms.Timer TimerSkillCoolDown;
	}
}