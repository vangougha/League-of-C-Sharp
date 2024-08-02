using System;
using Camille.Enums;
using Camille.RiotGames;
using Camille.RiotGames.SummonerV4;
using Camille.RiotGames.LeagueV4;


namespace LeagueOfCSharp
{
    class Program
    {
        public static void GetTopChampions()
        {
            var riotApi = RiotGamesApi.NewInstance("RGAPI-cfdf3190-6fee-41f1-8a61-51bbc5b71b45");

            // Assuming both API calls return types that share a common interface or base class
            var summoners = new[]
            {
                riotApi.AccountV1().GetByRiotId(RegionalRoute.EUROPE, "communistcomrade", "CCCP"),
            };
            foreach (var summoner in summoners)
            {
                Console.WriteLine($"Summoner Id is : {summoner.GameName},\n ");
                var masteries = riotApi.ChampionMasteryV4().GetAllChampionMasteriesByPUUID(PlatformRoute.RU, summoner.Puuid);
                for (int i = 0; i < 10; i++)
                {
                    var mastery = masteries[i];
                    var champ = (Champion)mastery.ChampionId;
                    var lastPlayTime = (Champion)mastery.LastPlayTime;
                    Console.WriteLine("{0,3}) {1,-16} {2,10:N0} ({3})", i + 1, champ.ToString(), mastery.ChampionPoints, mastery.ChampionLevel);
                    Console.WriteLine($"Last play time : {lastPlayTime} ");
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
