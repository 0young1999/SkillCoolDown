using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace SpecialCampaignSkillCoolDown.Data
{
	/// <summary>
	/// 프로필
	/// </summary>
	internal class ProfileData
	{
		public ProfileData(string profileName)
		{
			_profileName = profileName;
			_CoolDown1 = 0;
			_list = new List<ProfileSkillData>();
		}
		private ProfileData() { }

		public string _profileName = "";

		public int _CoolDown1 { get; set; }

		/// <summary>
		/// 스킬 리스트
		/// </summary>
		public List<ProfileSkillData> _list { get; set; }

		/// <summary>
		/// 불러오기
		/// </summary>
		public bool Load()
		{
			try
			{
				_list.Clear();

				XmlDocument xml = new XmlDocument();
				xml.Load("profil\\" + _profileName + ".xml");

				try { _CoolDown1 = int.Parse(xml.SelectSingleNode("root/특수스킬").InnerText); } catch { }

				XmlNodeList nodeList = xml.SelectSingleNode("root/SKILLS").ChildNodes;

				foreach (XmlNode node in nodeList)
				{
					ProfileSkillData detail = new ProfileSkillData(node.Attributes["name"].Value);
					detail.Load(node);
					_list.Add(detail);
				}
				return true;
			}
			catch { }
			return false;
		}

		/// <summary>
		/// 저장
		/// </summary>
		public void Save()
		{
			try
			{
				XmlDocument xml = new XmlDocument();

				XmlNode root = xml.CreateElement("root");
				xml.AppendChild(root);

				XmlNode 특수스킬 = xml.CreateElement("특수스킬");
				특수스킬.InnerText = _CoolDown1.ToString();
				root.AppendChild(특수스킬);

				XmlNode Skills = xml.CreateElement("SKILLS");
				root.AppendChild(Skills);

				foreach (ProfileSkillData item in _list)
				{
					XmlNode skill = item.Save(xml);
					Skills.AppendChild(skill);
				}

				xml.Save("profil\\" + _profileName + ".xml");
			}
			catch (Exception ex)
			{
				MessageBox.Show(_profileName + "을 저장하는 대 실패 하였습니다.\n" + ex.Message);
			}
		}
	}
}
