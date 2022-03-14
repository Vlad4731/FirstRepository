using System;
using Xunit;

namespace FootballRanking
{
    public class RankingFacts
    {
        [Fact]
        static void TeamCanBeAddedToRanking()
        {
            Team echipa = new Team("CFR", 22);
            Ranking clasament = new Ranking(new Ranking.TeamRanking[1]);
            clasament.AddTeamToRanking(echipa, 0);
            Assert.Equal(0, clasament.ReportTeamPlaceInRanking(echipa));
        }
    }
}
