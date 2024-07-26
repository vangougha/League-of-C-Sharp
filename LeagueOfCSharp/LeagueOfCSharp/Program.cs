using System;
using Camille.Enums;
using Camille.RiotGames;


namespace LeagueOfCSharp
{
    class Program
    {

        public static void GetTopChampions()
        {
            var riotApi = RiotGamesApi.NewInstance("RGAPI-e67364f6-c6bf-4a4e-b5ef-b6969130d0f5");

            var summoners = new[]
            {
                    riotApi.SummonerV4().GetBySummonerId(PlatformRoute.RU,"communistcomrade#CCCP")

        };
            foreach (var summoner in summoners)
            {
                Console.WriteLine($"Summoner Id is : {summoner.Id} ,\n and Summoner Level is  {summoner.SummonerLevel}");
                var masteries = riotApi.ChampionMasteryV4().GetAllChampionMasteriesByPUUID(PlatformRoute.RU, summoner.Puuid);
                for (int i = 0; i < 10; i++)
                {
                    var mastery = masteries[i];
                    var champ = (Champion)mastery.ChampionId;
                    Console.WriteLine("{0,3}) {1,-16} {2,10:N0} ({3})", i + 1, champ.ToString(),
              mastery.ChampionPoints, mastery.ChampionLevel);
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            GetTopChampions();
        }

    }
}
