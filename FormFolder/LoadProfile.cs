using SpecialCampaignSkillCoolDown.Data;
using System;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown.FormFolder
{
	public partial class LoadProfile : Form
	{
		public LoadProfile()
		{
			InitializeComponent();
		}

		private static ProfileList _profileList = ProfileList.GetInstance();

		private void BT_EXIT_Click(object sender, EventArgs e)
		{
			Application.ExitThread();
			Environment.Exit(0);
		}

		private void BT_OK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LoadProfile_Load(object sender, EventArgs e)
		{
			if (!_profileList.Load()) _profileList.Save();

			listBox1.Items.Add(string.Format("{0} : {1}", "현재 선택된 프로필", _profileList._profileSelect));
			listBox1.Items.Add(string.Format("{0} : {1}", "      로딩  상태      ", "프로필 명"));
			//listBox1.Items.Add(string.Format("{0} : {1}", "        READY        ", "      프로필 명"));
			//listBox1.Items.Add(string.Format("{0} : {1}", "          LOAD        ", "      프로필 명"));

			for (int i = 0; i < _profileList._profileList.Count; i++)
			{
				listBox1.Items.Add(string.Format("{0} : {1}", "        READY        ", _profileList._profileList[i]._profileName));
			}

			for (int i = 0; i < _profileList._profileList.Count; i++)
			{
				if (!_profileList._profileList[i].Load()) _profileList._profileList[i].Save();
				listBox1.Items[i + 2] = string.Format("{0} : {1}", "          LOAD        ", _profileList._profileList[i]._profileName);
			}
		}
	}
}
