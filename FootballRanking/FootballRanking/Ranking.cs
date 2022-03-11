using System;
using System.Collections.Generic;

namespace FootballRanking
{
    class Ranking
    {
        public Ranking()
        {
            for (int i = 0; i < 30; i++)
            {
                footballTeams[i] = new Team();
            }
        }

        public struct Team
        {
            public string TeamName { get; set; }
            public string TeamPoints { get; set; }
        }

        private Team[] footballTeams = new Team[30];

        public void AddTeam(string teamName, int placement)
        {
            footballTeams[placement] = new Team { TeamName = teamName };
        }

        public int GetTeamPlacement(string teamName)
        {
            for (int i = 0; i < footballTeams.Length; i++)
            {
                if (footballTeams[i].TeamName == teamName)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
