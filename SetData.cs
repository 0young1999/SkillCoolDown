using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SpecialCampaignSkillCoolDown
{
	internal class SetData
	{
		private SetData() 
		{
			for(int i = 0; i < 10; i++)
			{
				skillEnable[i] = false;
				skillName[i] = "";
				skillCoolDown[i] = 0;
				skillDuration[i] = 0;
				skillUnique[i] = false;
			}
		}
		public static SetData instance;
		public static SetData GetInstance()
		{
			if (instance == null)
			{
				instance = new SetData();
			}
			return instance;
		}

		public bool[] skillEnable = new bool[10];
		public string[] skillName = new string[10];
		public int[] skillCoolDown = new int[10];
		public int[] skillDuration = new int[10];
		public bool[] skillUnique = new bool[10];

		public bool SaveSettingData()
		{
			try
			{
				XmlDocument xml = new XmlDocument();

				XmlNode root = xml.CreateElement("root");
				xml.AppendChild(root);

				for(int i = 0; i < 10; i++)
				{
					XmlNode xmlSkillEnable = xml.CreateElement("skillEnable" + i);
					xmlSkillEnable.InnerText = skillEnable[i].ToString();
					xml.AppendChild(xmlSkillEnable);

				}
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}