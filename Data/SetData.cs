using System;
using System.Xml;

namespace SpecialCampaignSkillCoolDown
{
	internal class SetData
	{
		private SetData()
		{
			for (int i = 0; i < 10; i++)
			{
				skillEnable[i] = false;
				intSkillBind[i] = 0;
				stringSkillBInd[i] = " ";
				skillName[i] = " ";
				skillCoolDown[i] = 0;
				skillDuration[i] = 0;
				skillUnique[i] = false;
				tcpUsing[i] = false;
			}
			ReadSettingData();
		}
		private static SetData _instance;
		public static SetData GetInstance()
		{
			if (_instance == null)
			{
				_instance = new SetData();
			}
			return _instance;
		}

		public bool[] skillEnable = new bool[10];   // 사용여부
		public int[] intSkillBind = new int[10];    // 바인드키 int
		public string[] stringSkillBInd = new string[10];   // 키 이름
		public string[] skillName = new string[10]; // 스킬이름
		public long[] skillCoolDown = new long[10]; // 쿨다운
		public long[] skillDuration = new long[10]; // 스킬 작동시간
		public bool[] skillUnique = new bool[10];   // 고유스킬여부
		public bool[] tcpUsing = new bool[10];		// 서버 전송 여부
		public int intHookPause = 13;               // 후킹 일시정지 키 int
		public string stringHookPause = "Return";   // 후킹 일시정지 키 string
		public int intGameMode = 123;               // 게임모드 int
		public string stringGameMode = "F12";       // 게임모드 string
		public int intDelete = 122;                 // 직전 스킬 삭제 int
		public string stringDelete = "F11";         // 직전 스킬 삭제 string
		public bool galeRoadEnable = false;         // 질풍가도 사용여부
		public long galeRoadCoolDown = 5;           // 질풍가도 쿨타임
		public int intCorrection = 121;             // 맵 로딩 보정 int
		public string stringCorrection = "F10";     // 맵 로딩 보정 string
		public string ServerIp = "127.0.0.1";       // server ip
		public int ServerPort = 8000;               // server port
		public string playerName = "임시";            // server player name

		public string verstion = "0.1.1V3";


		public bool SaveSettingData()
		{
			try
			{
				XmlDocument xml = new XmlDocument();

				XmlNode root = xml.CreateElement("root");
				xml.AppendChild(root);

				for (int i = 0; i < 10; i++)
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
					xmlStringSkillBind.InnerText = stringSkillBInd[i].Equals("") ? " " : stringSkillBInd[i];
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

					XmlNode xmlTCPUsing = xml.CreateElement("TCPUsing" + i);
					xmlTCPUsing.InnerXml = tcpUsing[i].ToString();
					skillRoot.AppendChild(xmlTCPUsing);
				}

				XmlNode xmlDoubleKeySkill = xml.CreateElement("DoubleKeySkill");

				XmlNode xmlGaleRoadEnable = xml.CreateElement("GaleRoadEnable");
				xmlGaleRoadEnable.InnerText = galeRoadEnable.ToString();
				xmlDoubleKeySkill.AppendChild(xmlGaleRoadEnable);

				XmlNode xmlGaleRoadCoolDown = xml.CreateElement("GaleRoadCoolDown");
				xmlGaleRoadCoolDown.InnerText = galeRoadCoolDown.ToString();
				xmlDoubleKeySkill.AppendChild(xmlGaleRoadCoolDown);

				root.AppendChild(xmlDoubleKeySkill);

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

				XmlNode xmlDelete = xml.CreateElement("Delete");

				XmlNode xmlDeleteInt = xml.CreateElement("int");
				xmlDeleteInt.InnerText = intDelete.ToString();
				xmlDelete.AppendChild(xmlDeleteInt);

				XmlNode xmlDeleteString = xml.CreateElement("string");
				xmlDeleteString.InnerText = stringDelete;
				xmlDelete.AppendChild(xmlDeleteString);

				root.AppendChild(xmlDelete);

				XmlNode xmlCorrection = xml.CreateElement("Correction");

				XmlNode xmlCorrectionInt = xml.CreateElement("int");
				xmlCorrectionInt.InnerText = intCorrection.ToString();
				xmlCorrection.AppendChild(xmlCorrectionInt);

				XmlNode xmlCorrectionString = xml.CreateElement("string");
				xmlCorrectionString.InnerText = stringCorrection;
				xmlCorrection.AppendChild(xmlCorrectionString);

				root.AppendChild(xmlCorrection);

				XmlNode xmlServer = xml.CreateElement("SERVER");
				XmlNode xmlServerIp = xml.CreateElement("IP");
				xmlServerIp.InnerText = ServerIp;
				xmlServer.AppendChild(xmlServerIp);
				XmlNode xmlServerPort = xml.CreateElement("PORT");
				xmlServerPort.InnerText = ServerPort.ToString();
				xmlServer.AppendChild(xmlServerPort);
				XmlNode xmlServerPlayerName = xml.CreateElement("PlayerName");
				xmlServerPlayerName.InnerText = playerName;
				xmlServer.AppendChild(xmlServerPlayerName);

				root.AppendChild(xmlServer);

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

				for (int i = 0; i < 10; i++)
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
						XmlNode temp = skillRoot.SelectSingleNode("TCPUsing" + i);
						if(temp == null) { continue; }
						tcpUsing[i] = bool.Parse(temp.InnerText);
					}
					catch (NullReferenceException)
					{
						return false;
					}
				}

				try
				{
					XmlNode xmlDoubleSkill = root.SelectSingleNode("DoubleKeySkill");
					galeRoadEnable = bool.Parse(xmlDoubleSkill.SelectSingleNode("GaleRoadEnable").InnerText);
					galeRoadCoolDown = long.Parse(xmlDoubleSkill.SelectSingleNode("GaleRoadCoolDown").InnerText);
				}
				catch { }

				XmlNode xmlHookPause = root.SelectSingleNode("hookPuase");
				intHookPause = int.Parse(xmlHookPause.SelectSingleNode("int").InnerText);
				stringHookPause = xmlHookPause.SelectSingleNode("string").InnerText;

				XmlNode xmlGameMode = root.SelectSingleNode("GameMode");
				intGameMode = int.Parse(xmlGameMode.SelectSingleNode("int").InnerText);
				stringGameMode = xmlGameMode.SelectSingleNode("string").InnerText;

				XmlNode xmlDelete = root.SelectSingleNode("Delete");
				intDelete = int.Parse(xmlDelete.SelectSingleNode("int").InnerText);
				stringDelete = xmlDelete.SelectSingleNode("string").InnerText;

				XmlNode xmlCorrection = root.SelectSingleNode("Correction");
				intCorrection = int.Parse(xmlCorrection.SelectSingleNode("int").InnerText);
				stringCorrection = xmlCorrection.SelectSingleNode("string").InnerText;

				XmlNode xmlServer = root.SelectSingleNode("SERVER");
				ServerIp = xmlServer.SelectSingleNode("IP").InnerText;
				ServerPort = int.Parse(xmlServer.SelectSingleNode("PORT").InnerText);
				playerName = xmlServer.SelectSingleNode("PlayerName").InnerText;
			}
			catch { return false; }
			return true;
		}
	}
}