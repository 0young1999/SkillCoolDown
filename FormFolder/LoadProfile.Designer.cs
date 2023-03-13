namespace SpecialCampaignSkillCoolDown.FormFolder
{
	partial class LoadProfile
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.BT_OK = new System.Windows.Forms.Button();
			this.BT_EXIT = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(12, 36);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(776, 400);
			this.listBox1.TabIndex = 0;
			// 
			// BT_OK
			// 
			this.BT_OK.Location = new System.Drawing.Point(12, 7);
			this.BT_OK.Name = "BT_OK";
			this.BT_OK.Size = new System.Drawing.Size(75, 23);
			this.BT_OK.TabIndex = 1;
			this.BT_OK.Text = "OK";
			this.BT_OK.UseVisualStyleBackColor = true;
			this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
			// 
			// BT_EXIT
			// 
			this.BT_EXIT.Location = new System.Drawing.Point(713, 7);
			this.BT_EXIT.Name = "BT_EXIT";
			this.BT_EXIT.Size = new System.Drawing.Size(75, 23);
			this.BT_EXIT.TabIndex = 2;
			this.BT_EXIT.Text = "EXIT";
			this.BT_EXIT.UseVisualStyleBackColor = true;
			this.BT_EXIT.Click += new System.EventHandler(this.BT_EXIT_Click);
			// 
			// LoadProfile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.ControlBox = false;
			this.Controls.Add(this.BT_EXIT);
			this.Controls.Add(this.BT_OK);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadProfile";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LoadProfile";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.LoadProfile_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button BT_OK;
		private System.Windows.Forms.Button BT_EXIT;
	}
}