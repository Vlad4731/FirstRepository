using System;
using Xunit;

namespace FootballRanking
{
    public class RankingFacts
    {
        [Fact]
        static void TeamsCanBeAddedToRanking()
        {
            Team echipa = new Team("CFR", 22);
            Ranking clasament = new Ranking(new Ranking.TeamRanking[1]);
            clasament.AddTeamToRanking(echipa, 0);
            Assert.Equal(0, clasament.ReportTeamPlaceInRanking(echipa));
        }

        [Fact]
        static void TeamsCanBeSorted()
        {
            Team echipa1 = new Team("CFR", 22);
            Team echipa2 = new Team("Steaua", 20);
            Team echipa3 = new Team("Dinamo", 17);
            Ranking clasament = new Ranking(new Ranking.TeamRanking[3]);
            clasament.AddTeamToRanking(echipa1, 0);
            clasament.AddTeamToRanking(echipa2, 0);
            clasament.AddTeamToRanking(echipa3, 0);
            clasament.SortTeamsInRanking();
            Assert.Equal(0, clasament.ReportTeamPlaceInRanking(echipa1));
        }
    }
}
