namespace FootballRanking
{
    public class Team
    {
        private readonly string name;
        private int teamPoints = 0;
        private int wins = 0;
        private int losses = 0;
        private int draws = 0;

        public Team(string Name)
        {
            name = Name;
        }

        public int GetPoints()
        {
            return teamPoints;
        }

        private void CalculatePoints()
        {
            teamPoints = wins * 3 + draws + 0 * losses;
        }

        public void AddWin()
        {
            wins++;
            CalculatePoints();
        }

        public void AddDraw()
        {
            draws++;
            CalculatePoints();
        }
        public void AddLoss()
        {
            losses++;
            CalculatePoints();
        }
    }
}