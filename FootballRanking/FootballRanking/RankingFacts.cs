using System;
using Xunit;

namespace FootballRanking
{
    public class RankingFacts
    {
        [Fact]
        static void TeamsCanBeAddedToRanking()
        {
            Team echipa = new Team("CFR");
            Ranking clasament = new Ranking(new Team[0]);
            clasament.Add(echipa);
            Assert.Equal(0, clasament.PositionOf(echipa));
        }

        [Fact]
        static void TeamsCanBeSorted()
        {
            Ranking clasament = new Ranking(new Team[0]);
            clasament.Add(new Team("Steaua"));
            Team echipa = new Team("CFR");
            clasament.Add(echipa);
            echipa.AddWin();
            clasament.Add(new Team("Universitatea Craiova"));
            Assert.False(clasament.PositionOf(echipa) == 1);
            Assert.True(clasament.PositionOf(echipa) == 0);
        }
    }
}
