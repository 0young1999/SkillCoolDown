using System.Xml;

namespace SpecialCampaignSkillCoolDown.Data
{
	internal class ProfileSkillData
	{
		private ProfileSkillData() { }
		public ProfileSkillData(string name)
		{
			_enable = false;
			_tcpEnable = false;
			_skillType = false;
			_keyInt = 0;
			_keyStr = " ";
			_name = name;
			_coolTime = 0;
			_duration = 0;
		}

		/// <summary>
		/// 사용 여부
		/// </summary>
		public bool _enable { get; set; }

		/// <summary>
		/// 서버 연결 사용 여부
		/// </summary>
		public bool _tcpEnable { get; set; }

		/// <summary>
		/// 지속시간 쿨타임 포함 여부
		/// </summary>
		public bool _skillType { get; set; }

		/// <summary>
		/// 바인드 키 int 값 1
		/// </summary>
		public int _keyInt { get; set; }

		/// <summary>
		/// 바인드 키 string 값 2 
		/// </summary>
		public string _keyStr { get; set; }

		/// <summary>
		/// 스킬 명
		/// </summary>
		public string _name { get; set; }

		/// <summary>
		/// 스킬 쿨 타임
		/// </summary>
		public long _coolTime { get; set; }

		/// <summary>
		/// 스킬 작동 시간
		/// </summary>
		public long _duration { get; set; }

		public XmlNode Save(XmlDocument xml)
		{
			XmlNode node = xml.CreateElement("skill");
			XmlAttribute attr = xml.CreateAttribute("name");
			attr.Value = _name;
			node.Attributes.Append(attr);

			XmlNode enable = xml.CreateElement("enable");
			enable.InnerText = _enable.ToString();
			node.AppendChild(enable);

			XmlNode tcpEnable = xml.CreateElement("tcpEnable");
			tcpEnable.InnerText = _tcpEnable.ToString();
			node.AppendChild(tcpEnable);

			XmlNode skillType = xml.CreateElement("skillType");
			skillType.InnerText = _skillType.ToString();
			node.AppendChild(skillType);

			XmlNode keyInt1 = xml.CreateElement("keyInt1");
			keyInt1.InnerText = _keyInt.ToString();
			node.AppendChild(keyInt1);

			XmlNode keyStr1 = xml.CreateElement("keyStr1");
			keyStr1.InnerText = _keyStr.ToString();
			node.AppendChild(keyStr1);

			XmlNode coolTime = xml.CreateElement("coolTime");
			coolTime.InnerText = _coolTime.ToString();
			node.AppendChild(coolTime);

			XmlNode duration = xml.CreateElement("duration");
			duration.InnerText = _duration.ToString();
			node.AppendChild(duration);

			return node;
		}

		public void Load(XmlNode node)
		{
			try { _enable = bool.Parse(node.SelectSingleNode("enable").InnerText); } catch { }
			try { _tcpEnable = bool.Parse(node.SelectSingleNode("tcpEnable").InnerText); } catch { }
			try { _skillType = bool.Parse(node.SelectSingleNode("skillType").InnerText); } catch { }
			try { _keyInt = int.Parse(node.SelectSingleNode("keyInt1").InnerText); } catch { }
			try { _keyStr = node.SelectSingleNode("keyStr1").InnerText; } catch { }
			try { _coolTime = long.Parse(node.SelectSingleNode("coolTime").InnerText); } catch { }
			try { _duration = long.Parse(node.SelectSingleNode("duration").InnerText); } catch { }
		}
	}
}