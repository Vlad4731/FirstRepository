using System;
using Xunit;

namespace FootballRanking
{
    public class TeamFacts
    {
        [Fact]
        static void PointsAreSetAndReturnedCorrectly()
        {
            Team echipa = new Team("CFR", 20);
            echipa.SetPoints(22);
            Assert.Equal(22, echipa.GetPoints());
        }
    }
}
