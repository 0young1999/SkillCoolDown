using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

// https://unininu.tistory.com/475

namespace SpecialCampaignSkillCoolDown
{
	internal class TCPClient
	{
		private TCPClient() { }
		private static TCPClient _instance;
		public static TCPClient GetInstance()
		{
			if (_instance == null) _instance = new TCPClient();
			return _instance;
		}

		private SetData _data = SetData.GetInstance();

		private Thread _readThread;

		private bool _connState = false;
		public bool GetConnState() { return _connState; }

		StreamReader streamReader;
		StreamWriter streamWriter;

		public void Open()
		{
			_connState = true;
			Thread openThread = new Thread(Connect);
			openThread.IsBackground = true;
			openThread.Start();
		}

		private void Connect()
		{
			try
			{
				// TcpClient 객체 생성
				TcpClient tcpClient1 = new TcpClient();
				// IP주소와 Port번호를 할당
				IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(_data.ServerIp), _data.ServerPort);
				tcpClient1.Connect(ipEnd);  // 서버에 연결 요청

				streamReader = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
				streamWriter = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
				streamWriter.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

				_readThread = new Thread(ReadServerMessage);
				_readThread.IsBackground = true;
				_readThread.Start();

				streamWriter.WriteLine((char)02 + ",NEW," + _data.playerName + "님,입장(" + _data.verstion + "),10000,10000,false," + (char)03);
			}
			catch
			{
				_connState = false;
			}
		}

		private void ReadServerMessage()
		{
			try
			{
				while (_connState)
				{
					string[] msg = streamReader.ReadLine().Split(',');

					// 스킬 가동
					if (msg.Length == 8)
					{
						if (msg[0] == ((char)02).ToString() && msg[7].IndexOf((char)03) == 0)
						{
							// 1:이벤트 내용 2:닉네임 3:스킬명 4:쿨타임 5:작동시간 6:고유스킬 여부
							string eventType = msg[1];
								// 2:닉네임
							string player = msg[2];
								// 3:스킬명
							string name = msg[3];
								// 4:쿨타임
							long coolDown = 0;
							if (!long.TryParse(msg[4], out coolDown)) continue;
								// 5:작동시간
							long duration = 0;
							if (!long.TryParse(msg[5], out duration)) continue;
								// 6:고유스킬 여부
							bool unique = false;
							if (!bool.TryParse(msg[6], out unique)) continue;

							ReqeustSkillNewEvent(eventType, player, name, coolDown, duration, unique);
						}
					}
				}
			}
			catch
			{
				_connState = false;
			}
		}

		public void Send(LeftSkillCoolDownClass skill, string eventType)
		{
			try
			{
				streamWriter.WriteLine((char)02 + "," + eventType + "," + _data.playerName + "," + skill.name + "," + skill.coolDown + "," + skill.duration + "," + skill.unique + "," + (char)03);
			}
			catch { }
		}

		public class ReqeustSkillNewEventArg : EventArgs
		{
			public string _eventType;
			public string _player;
			public string _name;
			public long _coolDown;
			public long _duration;
			public bool _unique;
		}
		public static EventHandler<ReqeustSkillNewEventArg> _ReqeustSkillNewEvent;
		public static void ReqeustSkillNewEvent(string eventType, string player, string name, long coolDown, long duration, bool unique)
		{
			_ReqeustSkillNewEvent.Invoke(_instance, new ReqeustSkillNewEventArg()
			{
				_eventType = eventType,
				_player = player,
				_name = name,
				_coolDown = coolDown,
				_duration = duration,
				_unique = unique,
			});
		}
	}
}
