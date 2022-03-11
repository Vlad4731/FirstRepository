using System;
using Xunit;

namespace FootballRanking
{
    public class RankingFacts
    {
        [Fact]
        public void ReportRankingPlacementOfTeam()
        {
            var ranking = new Ranking();
            ranking.AddTeam("CFR", 1);

            Assert.Equal(1, ranking.GetTeamPlacementByName("CFR"));
        }

        [Fact]
        public void ReportTeamFromInputRanking()
        {
            var ranking = new Ranking();
            ranking.AddTeam("CFR", 1);

            Assert.Equal("CFR", ranking.GetTeamPlacementByRanking(1));
        }
    }
}
