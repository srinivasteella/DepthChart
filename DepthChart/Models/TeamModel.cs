namespace DepthChart.Team.Model
{
    public class Player
    {
        public string number { get; set; }
        public string name { get; set; }
    }

    public class SportsTeam
    {
        public List<Team> Teams { get; set; }
    }

    public class Team
    {
        public string TeamName { get; set; }
        public List<Player> players { get; set; }
    }

    public class NFLTeam : SportsTeam { }
}
