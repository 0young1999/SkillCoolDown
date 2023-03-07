using SteamQueryNet;
using SteamQueryNet.Models;
using System.Collections.Generic;

namespace SpecialCampaignSkillCoolDown
{
	internal class SteamAPITest
	{
		public ServerQuery _serverQuery;

		public void con()
		{
			_serverQuery = new ServerQuery();
			_serverQuery.Connect("220.72.123.7", 27015);
		}

		public List<Player> Test()
		{
			List<Player> players = _serverQuery.GetPlayers();
			return players;
		}

		public int Test1()
		{
			return _serverQuery.RenewChallenge();
		}
	}
}
