﻿using System;

namespace FootballRanking
{
    public class Ranking
    {
        public struct TeamRanking
        {
            public readonly Team team;
            public int teamRanking;

            public TeamRanking(Team inputTeam, int inputRanking)
            {
                team = inputTeam;
                teamRanking = inputRanking;
            }
        }

        public TeamRanking[] teamRankings = new TeamRanking[20];

        public Ranking(TeamRanking[] rankings)
        {
            rankings = teamRankings;
        }

        public void AddTeamToRanking(Team team)
        {
            teamRankings[0] = new TeamRanking(team, 0);
        }

        public int ReportTeamPlaceInRanking(Team team)
        {
            foreach(var echipa in teamRankings)
            {
                if (echipa.team.GetName() == team.GetName())
                {
                    return echipa.teamRanking;
                }
            }

            return -1;
        }

    }
}
