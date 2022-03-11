namespace FootballRanking
{
    public class Team
    {
        private readonly string teamName;
        private int teamPoints;

        public Team(string Name, int Points)
        {
            Name = teamName;
            Points = teamPoints;
        }

        public void SetPoints(int newPoints)
        {
            teamPoints = newPoints;
        }

        public int GetPoints()
        {
            return teamPoints;
        }
    }
}