using System;

namespace FootballRanking
{
    public class Ranking
    {
        int rankIndex = 0;

        private Team[] teamsRanking = new Team[0];

        public Ranking(Team[] teams)
        {
            teamsRanking = teams;
        }

        public void Add(Team team)
        {
            Array.Resize(ref teamsRanking, rankIndex + 1);
            teamsRanking[rankIndex] = team;
            rankIndex++;
            Sort();
        }

        public int PositionOf(Team team)
        {
            for (int i = 0; i < rankIndex; i++)
            {
                if (teamsRanking[i] == team)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Match(Team home, Team away, int homeGoals, int awayGoals)
        {
            if(homeGoals > awayGoals)
            {
                home.AddWin();
            }
            else if (homeGoals < awayGoals)
            {
                away.AddWin();
            }
            else
            {
                home.AddDraw();
                away.AddDraw();
            }

            Sort();
        }

        public Team AtPosition(int i)
        {
            if (i < rankIndex)
            {
                return teamsRanking[i];
            }

            return null;

        }

        private void Sort()
        {
            bool match = true;
            while (match)
            {
                match = false;
                for (int i = 0; i < rankIndex - 1; i++)
                {
                    if (teamsRanking[i].TeamCompare(teamsRanking[i + 1]) == -1)
                    {
                        TeamSwap(i, i + 1);
                        match = true;
                    }
                }
            }
        }

        private void TeamSwap(int firstIndex, int secondIndex)
        {
            Team temp = teamsRanking[firstIndex];
            teamsRanking[firstIndex] = teamsRanking[secondIndex];
            teamsRanking[secondIndex] = temp;
        }
    }
}
