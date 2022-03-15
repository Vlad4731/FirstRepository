namespace FootballRanking
{
    public class Team
    {
        private readonly string name;
        private int teamPoints = 0;

        public Team(string Name)
        {
            name = Name;
        }

        public void AddWin()
        {
            teamPoints += 3;
        }

        public void AddDraw()
        {
            teamPoints += 1;
        }

        public int TeamCompare(Team team)
        {
            return teamPoints.CompareTo(team.teamPoints);
        }
    }
}