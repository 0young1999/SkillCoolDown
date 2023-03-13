using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SpecialCampaignSkillCoolDown.Data
{
	internal class ProfileList
	{
		private static ProfileList _instance;
		public static ProfileList GetInstance()
		{
			if (_instance == null) _instance = new ProfileList();
			return _instance;
		}
		private ProfileList()
		{
			_profileList = new List<ProfileData>();
			_profileSelect = "";
		}

		/// <summary>
		/// 마지막으로 선택된 프로필
		/// </summary>
		public string _profileSelect { get; set; }

		/// <summary>
		/// 프로필 리스트
		/// </summary>
		public List<ProfileData> _profileList { get; set; }

		public bool Load()
		{
			try
			{
				_profileList.Clear();

				XmlDocument xml = new XmlDocument();
				xml.Load("profil\\main.xml");

				XmlNode root = xml.SelectSingleNode("root");

				_profileSelect = root.SelectSingleNode("select").InnerText;

				XmlNodeList nodeList = root.SelectSingleNode("names").ChildNodes;

				foreach (XmlNode node in nodeList)
				{
					ProfileData data = new ProfileData(node.InnerText);
					data.Load();
					_profileList.Add(data);
				}

				return true;
			}
			catch { }
			return false;
		}

		public void Save()
		{
			try
			{
				XmlDocument xml = new XmlDocument();

				XmlNode root = xml.CreateElement("root");
				xml.AppendChild(root);

				XmlNode select = xml.CreateElement("select");
				select.InnerText = _profileSelect;
				root.AppendChild(select);

				XmlNode names = xml.CreateElement("names");

				foreach (ProfileData data in _profileList)
				{
					XmlNode node = xml.CreateElement("ProfileNAME");
					node.InnerText = data._profileName;
					names.AppendChild(node);

					data.Save();
				}

				root.AppendChild(names);

				xml.Save("profil\\main.xml");
			}
			catch
			{
				MessageBox.Show("프로필 저장중 오류");
			}
		}
	}
}
