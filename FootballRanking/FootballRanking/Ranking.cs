using System;

namespace FootballRanking
{
    public class Ranking
    {
        int rankIndex = 0;

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

        public void AddTeamToRanking(Team team, int rank)
        {
            teamRankings.SetValue(new TeamRanking(team, rank), rankIndex);
            rankIndex++;
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

        public void SortTeamsInRanking()
        {
            bool match = true;
            while (match)
            {
                match = false;
                for (int i = 0; i < rankIndex - 1; i++)
                {
                    if (teamRankings[i].team.GetPoints() < teamRankings[i + 1].team.GetPoints())
                    {
                        TeamSwap(teamRankings, i, i + 1);
                        match = true;
                    }
                }
            }
        }

        static (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }

        static void TeamSwap(TeamRanking[] teams, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);

            TeamRanking temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

    }
}
