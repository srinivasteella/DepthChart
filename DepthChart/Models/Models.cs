using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DepthChart.Models
{
   


}
//    public class AddPlayer
//    {
//        public Position Position { get; set; }
//        public int Depth { get; set; }
//        public SportType SportType { get; set; }
//        public string TeamName { get; set; }

//    }

//    public class AddPlayerToDepthChart
//    {
//        public string Position { get; set; }
//        public string Name { get; set; }
//        public int Depth { get; set; }
//        public string SportType { get; set; }
//        public string TeamName { get; set; }

//    }
//    public class Player
//    {
//        public int No { get; set; }
//        public string Name { get; set; }
//    }

//    public class NFLTeams
//    {
//        public List<Team> Teams { get; set; }
//    }

//    public class Team
//    {
//        public string TeamName { get; set; }
//        public List<Player> Players { get; set; }        
//    }

//    public enum SportType
//    {
//        NFL =0,
//        NHL =1,
//    }
//    public enum Type
//    {
//        LWR=0,
//        RWR=1,
//        LT=2,
//        LG=3,
//        C=4,
//        RG=5,
//        RT=6,
//        TE=7,
//        QB=8,
//        RB=9
//    }
//    public abstract class Sport
//    {
//        public int Id { get; set; }
//        //public string SportName { get; set; }
//        public int TeamNumber { get; set; }
//        public string DChartType { get; set; }
//        public Data Data { get; set; }

//        [JsonConverter(typeof(StringEnumConverter))]
//        public abstract SportType SportType { get; }
//    }

//    public class NFL : Sport {
//        [JsonConverter(typeof(StringEnumConverter))]
//        public override SportType SportType => SportType.NFL;
//    }

//    public class Position
//    {
//        public Player Player { get; set; }
//    }

//    public class Data
//    {
//        public List<C>? C { get; set; }
//        public List<LWR>? LWR { get; set; }
//        public List<RWR>? RWR { get; set; }
//        public List<LT>? LT { get; set; }
//        public List<LG>? LG { get; set; }
//        public List<RG>? RG { get; set; }
//        public List<RT>? RT { get; set; }
//        public List<TE>? TE { get; set; }
//        public List<QB>? QB { get; set; }
//        public List<RB>? RB { get; set; }
//    }
//    public class C : Position {

//    }
//    public class LG : Position {
//    }

//    public class LT : Position {
//    }

//    public class LWR : Position {
//    }

//    public class QB : Position {
//    }

//    public class RB : Position {
//    }

//    public class RG : Position { }
//    public class RT : Position {
//    }

//    public class RWR : Position {
//    }

//    public class TE : Position {
//    }

//}
