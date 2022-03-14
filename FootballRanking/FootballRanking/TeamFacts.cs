using System;
using Xunit;

namespace FootballRanking
{
    public class TeamFacts
    {
        [Fact]
        static void PointsAreCalculatedAndReturned()
        {
            Team echipa = new Team("CFR");
            echipa.AddWin();
            echipa.AddWin();
            echipa.AddDraw();
            Assert.Equal(7, echipa.GetPoints());
        }
    }
}
