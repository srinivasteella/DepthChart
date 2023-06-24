using DepthChart.Models;
using DepthChart.Service;
using Newtonsoft.Json;
using Moq;

namespace DepthChartTest
{
    public class DepthChartServiceTests
    {
        Mock<INFLService> moqNFLService;
        NFLService nflService;
        public DepthChartServiceTests()
        {
            moqNFLService = new Mock<INFLService>();
            nflService = new NFLService();
        }
        [Theory]       
        [InlineData("Offense","LWR", "Mike Evans", 2,"NFL","Team1")]
        [InlineData("Offense","LWR", "Jaelon Darden", 8, "NFL", "Team1")]
        [InlineData("Offense","LWR", "Scott Miller", 1, "NFL", "Team1")]
        public void AddPlayer(string chartType,string positionType,string playername, int position_depth,string sportType,string teamName)
        {
            AddPlayerToDepthChart player = new AddPlayerToDepthChart
            {
                ChartType = chartType,
                Depth=position_depth,
                Name=playername,
                Position=positionType,
                SportType=sportType,
                TeamName=teamName                
            };

            nflService.addPlayerToDepthChart(player);
            

        }

        [Theory]
        [InlineData("Offense", "LWR", "Mike Evans", "NFL", "Team2")]
        [InlineData("Offense", "LWR", "Jaelon Darden","NFL", "Team1")]
        [InlineData("Defense", "LWR", "Scott Miller", "NFL", "Team1")]
        public void RemovePlayer(string chartType, string positionType, string playername, string sportType, string teamName)
        {
            RemovePlayerFromDepthChart playertoberemoved = new RemovePlayerFromDepthChart
            {
                ChartType = chartType,
                Name = playername,
                Position = positionType,
                SportType = sportType,
                TeamName = teamName
            };

            nflService.removePlayerFromDepthChart(playertoberemoved);

        }

        [Theory]
        [InlineData("Offense", "LWR", "Mike Evans", "NFL", "Team1")]
        [InlineData("Offense", "LWR", "Jaelon Darden", "NFL", "Team1")]
        [InlineData("Defense", "LWR", "Scott Miller", "NFL", "Team1")]
        public void GetBackups(string chartType, string positionType, string playername, string sportType, string teamName)
        {
            ChartBackup chartbackup = new ChartBackup
            {
                ChartType = chartType,
                Name = playername,
                Position = positionType,
                SportType = sportType,
                TeamName = teamName
            };

            var result = nflService.getBackups(chartbackup);

        }

        [Fact]
        public void GetDepthChart()
        {            
            var result = nflService.getFullDepthChart();

        }

    }
}