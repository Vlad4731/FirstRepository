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
            clasament.Add(new Team("Universitatea Cluj"));
            Assert.False(clasament.PositionOf(echipa) == 1);
            Assert.True(clasament.PositionOf(echipa) == 0);
        }

        [Fact]
        static void CanRetrieveTeamFromPosition()
        {
            Team echipa = new Team("CFR");
            Ranking clasament = new Ranking(new Team[0]);
            clasament.Add(echipa);
            Assert.Equal(echipa, clasament.AtPosition(0));
            Assert.Null(clasament.AtPosition(25));
        }

        [Fact]
        static void MatchPointsCanModifyRanking()
        {
            Ranking clasament = new Ranking(new Team[0]);
            Team home = new Team("CFR");
            clasament.Add(home);
            Team away = new Team("Universitatea Cluj");
            clasament.Add(away);
            clasament.Match(home, away, 2, 4);
            Assert.True(clasament.PositionOf(away) == 0);
            Assert.False(clasament.PositionOf(home) == 0);
        }
    }
}
