using DepthChart.Models;
using Newtonsoft.Json;

namespace DepthChartTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetBackUps()
        {
            var data = System.IO.File.ReadAllText("NFLDepthChart.json");
            NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data);
            var result = jsonObj.Data.C.FindIndex(a => a.Player.Name.Equals("Arjun"));
            var f = result != -1 ? jsonObj.Data.C.Skip(result+1) : new List<C>();          

        }

        [Theory]       
        //[InlineData("Arjun", 24 , 0)]
        [InlineData("Kyle Trask", 2, 8)]
       // [InlineData("Diya", 16, 3)]
        public void AddPlayer(string playername,int playerid,int position_depth)
        {
            AddPlayer player = new AddPlayer
            {
                sportType = SportType.NFL,
                position = new C { Player = new Player { Name = playername, No = playerid } }
            };

            var test = JsonConvert.SerializeObject(player);
            var data = System.IO.File.ReadAllText("NFLDepthChart.json");
            NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data); // find type of sport
            var index = jsonObj.Data.C.FindIndex(a => a.Player.Name == player.position.Player.Name);
            if (index == -1)
            {
                if (position_depth >= jsonObj.Data.C.Count)
                    jsonObj.Data.C.Add((C)player.position);
                else
                jsonObj.Data.C.Insert(position_depth, (C)player.position); // find the type of position and cast //look for exisitng player for same depth
                
                string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("NFLDepthChart.json", output);
            }
            else if(position_depth != index)  //edge case what if end item want to add again with more depth 
            {                
                C item = jsonObj.Data.C[index];
                jsonObj.Data.C.RemoveAt(index);

                if (position_depth >= jsonObj.Data.C.Count)
                    jsonObj.Data.C.Add(item);
                else jsonObj.Data.C.Insert(position_depth, item);
                
                string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("NFLDepthChart.json", output);
            }
        }

        [Fact]
        public void RemovePlayer()
        {            
            var data = System.IO.File.ReadAllText("NFLDepthChart.json");
            NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data); // find type of sport
            var index = jsonObj.Data.QB.FindIndex(a => a.Player.Name.Equals("Daren"));
            if (index != -1)
            {
                jsonObj.Data.C.RemoveAt(index); // find the type of position and cast //look for exisitng player for same depth
                string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("NFLDepthChart.json", output);
            }
        }

        [Fact]
        public void GetFullDepthChart()
        {
            var data = System.IO.File.ReadAllText("NFLDepthChart.json");
            NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data); // find type of sport           
        }
    }
}