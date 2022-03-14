﻿using System;

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

        public string AtPosition(int i)
        {
            return i < rankIndex ? teamsRanking[i].ToString() : "Pozitie neocupata.";
        }

        private void Sort()
        {
            bool match = true;
            while (match)
            {
                match = false;
                for (int i = 0; i < rankIndex - 1; i++)
                {
                    if (teamsRanking[i].GetPoints() < teamsRanking[i + 1].GetPoints())
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
