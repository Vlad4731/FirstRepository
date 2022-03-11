using System;
using Xunit;

namespace FootballRanking
{
    public class RankingFacts
    {
        [Fact]
        public void RankReportTest()
        {
            var ranking = new Ranking();
            ranking.AddTeam("CFR", 1);

            Assert.Equal(1, ranking.GetTeamPlacement("CFR"));
        }
    }
}
