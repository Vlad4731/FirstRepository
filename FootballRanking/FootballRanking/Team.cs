namespace FootballRanking
{
    public class Team
    {
        private readonly string teamName;
        private int teamPoints;

        public Team(string Name, int Points)
        {
            teamName = Name;
            teamPoints = Points;
        }

        public void SetPoints(int newPoints)
        {
            teamPoints = newPoints;
        }

        public int GetPoints()
        {
            return teamPoints;
        }
        public string GetName()
        {
            return teamName;
        }
    }
}