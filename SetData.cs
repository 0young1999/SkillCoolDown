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

		public bool[] skillEnable = new bool[10];	// 사용여부
		public int[] intSkillBind = new int[10];	// 바인드키 int
		public string[] stringSkillBInd = new string[10];	// 키 이름
		public string[] skillName = new string[10];	// 스킬이름
		public long[] skillCoolDown = new long[10];	// 쿨다운
		public long[] skillDuration = new long[10];	// 스킬 작동시간
		public bool[] skillUnique = new bool[10];   // 고유스킬여부
		public int intHookPause = 13;				// 후킹 일시정지 키 int
		public string stringHookPause = "Return";   // 후킹 일시정지 키 string
		public int intGameMode = 123;				// 게임모드 int
		public string stringGameMode = "F12";		// 게임모드 string

		public bool SaveSettingData()
		{
			try
			{
				XmlDocument xml = new XmlDocument();

				XmlNode root = xml.CreateElement("root");
				xml.AppendChild(root);

				for(int i = 0; i < 10; i++)
				{
					XmlNode skillRoot = xml.CreateElement("Skill" + i);
					root.AppendChild(skillRoot);

					XmlNode xmlSkillEnable = xml.CreateElement("Enable" + i);
					xmlSkillEnable.InnerText = skillEnable[i].ToString();
					skillRoot.AppendChild(xmlSkillEnable);

					XmlNode xmlIntSkillBind = xml.CreateElement("IntBind" + i);
					xmlIntSkillBind.InnerText = intSkillBind[i].ToString();
					skillRoot.AppendChild(xmlIntSkillBind);

					XmlNode xmlStringSkillBind = xml.CreateElement("StringBind" + i);
					xmlStringSkillBind.InnerText = stringSkillBInd[i].Equals("")? " ": stringSkillBInd[i];
					skillRoot.AppendChild(xmlStringSkillBind);

					XmlNode xmlSkillName = xml.CreateElement("Name" + i);
					xmlSkillName.InnerText = skillName[i].Equals("") ? " " : skillName[i];
					skillRoot.AppendChild(xmlSkillName);

					XmlNode xmlSkillCoolDown = xml.CreateElement("CoolDown" + i);
					xmlSkillCoolDown.InnerText = skillCoolDown[i].ToString();
					skillRoot.AppendChild(xmlSkillCoolDown);

					XmlNode xmlSkillDuration = xml.CreateElement("Duration" + i);
					xmlSkillDuration.InnerText = skillDuration[i].ToString();
					skillRoot.AppendChild(xmlSkillDuration);

					XmlNode xmlSkillUnique = xml.CreateElement("Unique" + i);
					xmlSkillUnique.InnerText = skillUnique[i].ToString();
					skillRoot.AppendChild(xmlSkillUnique);
				}

				XmlNode xmlHookPause = xml.CreateElement("hookPuase");

				XmlNode xmlHookPauseInt = xml.CreateElement("int");
				xmlHookPauseInt.InnerText = intHookPause.ToString();
				xmlHookPause.AppendChild(xmlHookPauseInt);

				XmlNode xmlHookPauseString = xml.CreateElement("string");
				xmlHookPauseString.InnerText = stringHookPause;
				xmlHookPause.AppendChild(xmlHookPauseString);

				root.AppendChild(xmlHookPause);

				XmlNode xmlGameMode = xml.CreateElement("GameMode");

				XmlNode xmlGameModeInt = xml.CreateElement("int");
				xmlGameModeInt.InnerText = intGameMode.ToString();
				xmlGameMode.AppendChild(xmlGameModeInt);

				XmlNode xmlGameModeString = xml.CreateElement("string");
				xmlGameModeString.InnerText = stringGameMode;
				xmlGameMode.AppendChild(xmlGameModeString);

				root.AppendChild(xmlGameMode);


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
						XmlNode skillRoot = root.SelectSingleNode("Skill" + i);
						skillEnable[i] = bool.Parse(skillRoot.SelectSingleNode("Enable" + i).InnerText);
						intSkillBind[i] = int.Parse(skillRoot.SelectSingleNode("IntBind" + i).InnerText);
						stringSkillBInd[i] = skillRoot.SelectSingleNode("StringBind" + i).InnerText;
						skillName[i] = skillRoot.SelectSingleNode("Name" + i).InnerText;
						skillCoolDown[i] = long.Parse(skillRoot.SelectSingleNode("CoolDown" + i).InnerText);
						skillDuration[i] = long.Parse(skillRoot.SelectSingleNode("Duration" + i).InnerText);
						skillUnique[i] = bool.Parse(skillRoot.SelectSingleNode("Unique" + i).InnerText);
					}
					catch (NullReferenceException)
					{
						return false;
					}
				}

				XmlNode xmlHookPause = root.SelectSingleNode("hookPuase");
				intHookPause = int.Parse(xmlHookPause.SelectSingleNode("int").InnerText);
				stringHookPause = xmlHookPause.SelectSingleNode("string").InnerText;

				XmlNode xmlGameMode = root.SelectSingleNode("GameMode");
				intGameMode = int.Parse(xmlGameMode.SelectSingleNode("int").InnerText);
				stringGameMode = xmlGameMode.SelectSingleNode("string").InnerText;
			}
			catch (Exception) { return false; }
			return true;
		}
	}
}