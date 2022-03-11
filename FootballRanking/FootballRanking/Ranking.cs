using System;
using System.Collections.Generic;

namespace FootballRanking
{
    class Ranking
    {
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

        public int GetTeamPlacementByName(string teamName)
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

        public string GetTeamPlacementByRanking(int inputRanking)
        {
            if (!string.IsNullOrEmpty(footballTeams[inputRanking].TeamName))
            {
                return footballTeams[inputRanking].TeamName;
            }

            return null;
        }

    }
}
