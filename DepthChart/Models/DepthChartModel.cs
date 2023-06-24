﻿namespace DepthChart.Models
{
    public enum SportType
    {
        NFL = 0,
        NHL = 1,
    }
    public enum PositionType
    {
        LWR = 0,
        RWR = 1,
        LT = 2,
        LG = 3,
        C = 4,
        RG = 5,
        RT = 6,
        TE = 7,
        QB = 8,
        RB = 9
    }

    public abstract class  DepthChartOpsInput{
        public string Position { get; set; }
        public string Name { get; set; }       
        public string SportType { get; set; }
        public string TeamName { get; set; }
        public string ChartType { get; set; }
    }
    public class ChartBackup: DepthChartOpsInput { }
    public class AddPlayerToDepthChart : DepthChartOpsInput
    {
        public int Depth { get; set; }
    }

    public class RemovePlayerFromDepthChart : DepthChartOpsInput { }

    public class DepthChart
    {
        public string ChartType { get; set; }
        public List<Position> Position { get; set; }
    }

    public class Player
    {
        public string number { get; set; }
        public string name { get; set; }
    }

    public class Position
    {
        public string Type { get; set; }
        public List<Player> Players { get; set; }
    }

    public class TeamDepthChart
    {
        public string SportType { get; set; }
        public int Id { get; set; }
        public List<Team> Teams { get; set; }
    }

    public class Team
    {
        public string TeamName { get; set; }
        public List<DepthChart> DepthCharts { get; set; }
    }


    public class NFLDepthChart: TeamDepthChart { }
}
