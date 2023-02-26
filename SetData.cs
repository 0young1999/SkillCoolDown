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
				intSkillBind[i] = 0;
				stringSkillBInd[i] = " ";
				skillName[i] = " ";
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
		public int[] intSkillBind = new int[10];
		public string[] stringSkillBInd = new string[10];
		public string[] skillName = new string[10];
		public long[] skillCoolDown = new long[10];
		public long[] skillDuration = new long[10];
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
					XmlNode xmlSkillEnable = xml.CreateElement("Enable" + i);
					xmlSkillEnable.InnerText = skillEnable[i].ToString();
					root.AppendChild(xmlSkillEnable);

					XmlNode xmlIntSkillBind = xml.CreateElement("IntBind" + i);
					xmlIntSkillBind.InnerText = intSkillBind[i].ToString();
					root.AppendChild(xmlIntSkillBind);

					XmlNode xmlStringSkillBind = xml.CreateElement("StringBind" + i);
					xmlStringSkillBind.InnerText = stringSkillBInd[i].Equals("")? " ": stringSkillBInd[i];
					root.AppendChild(xmlStringSkillBind);

					XmlNode xmlSkillName = xml.CreateElement("Name" + i);
					xmlSkillName.InnerText = skillName[i].Equals("") ? " " : skillName[i];
					root.AppendChild(xmlSkillName);

					XmlNode xmlSkillCoolDown = xml.CreateElement("CoolDown" + i);
					xmlSkillCoolDown.InnerText = skillCoolDown[i].ToString();
					root.AppendChild(xmlSkillCoolDown);

					XmlNode xmlSkillDuration = xml.CreateElement("Duration" + i);
					xmlSkillDuration.InnerText = skillDuration[i].ToString();
					root.AppendChild(xmlSkillDuration);

					XmlNode xmlSkillUnique = xml.CreateElement("Unique" + i);
					xmlSkillUnique.InnerText = skillUnique[i].ToString();
					root.AppendChild(xmlSkillUnique);
				}

				xml.Save("skill.xml");
			}
			catch
			{
				return false;
			}

			return true;
		}

		public bool ReadSettingData()
		{
			try
			{
				XmlDocument xml = new XmlDocument();
				xml.Load("skill.xml");

				XmlNode root = xml.SelectSingleNode("root");

				for(int i = 0; i < 10; i++)
				{
					try
					{
						skillEnable[i] = bool.Parse(root.SelectSingleNode("Enable" + i).InnerText);
						intSkillBind[i] = int.Parse(root.SelectSingleNode("IntBind" + i).InnerText);
						stringSkillBInd[i] = root.SelectSingleNode("StringBind" + i).InnerText;
						skillName[i] = root.SelectSingleNode("Name" + i).InnerText;
						skillCoolDown[i] = long.Parse(root.SelectSingleNode("CoolDown" + i).InnerText);
						skillDuration[i] = long.Parse(root.SelectSingleNode("Duration" + i).InnerText);
						skillUnique[i] = bool.Parse(root.SelectSingleNode("Unique" + i).InnerText);
					}
					catch (NullReferenceException)
					{
						return false;
					}
				}
			}
			catch (Exception) { return false; }
			return true;
		}
	}
}