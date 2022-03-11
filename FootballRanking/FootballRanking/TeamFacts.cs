using System;
using Xunit;

namespace FootballRanking
{
    public class TeamFacts
    {
        [Fact]
        static void CreateTeam()
        {
            Team echipa = new Team("CFR", 20);
            Assert.Equal(echipa, new Team("CFR", 20));
        }
    }
}
