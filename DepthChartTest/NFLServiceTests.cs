using DepthChart.Models;
using DepthChart.Service;
using Newtonsoft.Json;
using Moq;
using Player = DepthChart.Team.Model.Player;
using TeamPlayer = DepthChart.Models.Player;
namespace DepthChartTest
{
    public class NFLServiceTests
    {
        NFLService nflService;
        public NFLServiceTests()
        {
            nflService = new NFLService();
        }
        [Theory]       
        [InlineData("Offense","LWR", "mike Evans", 2,"NFL","Team1")]
        [InlineData("offense","LWR", "Jaelon Darden", 8, "NFL", "Team1")]
        [InlineData("Offense","LWR", "Scott Miller", 1, "nfl", "Team1")]
        public void AddPlayer_Return_True_OnSuccess(string chartType,string positionType,string playername, int position_depth,string sportType,string teamName)
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

            var result = nflService.addPlayerToDepthChart(player);

            Assert.True(result);           

        }
        [Theory]
        [InlineData("Offense", "LWR", "Tom", 2, "NFL", "Team1")]
        [InlineData("Offense", "LWR", "Chris", 8, "NFL", "Team1")]
        [InlineData("XYZ", "LWR", "Scott Miller", 1, "NFL", "Team1")]
        [InlineData("Offense", "XYZ", "Scott Miller", 1, "NFL", "Team1")]
        [InlineData("Offense", "LWR", "Scott Miller", 1, "NFL", "Team100")]
        public void AddPlayer_Return_False_WhenPlayerOrInputData_Invalid(string chartType, string positionType, string playername, int position_depth, string sportType, string teamName)
        {
            AddPlayerToDepthChart player = new AddPlayerToDepthChart
            {
                ChartType = chartType,
                Depth = position_depth,
                Name = playername,
                Position = positionType,
                SportType = sportType,
                TeamName = teamName
            };

            var result = nflService.addPlayerToDepthChart(player);

            Assert.False(result);

        }

        [Theory]
        [InlineData("Offense", "LWR", "Mike Evans", "NFL", "Team1")]
        [InlineData("Offense", "LWR", "Jaelon Darden", "NFL", "Team1")]
        [InlineData("Defense", "LWR", "Scott Miller", "NFL", "Team1")]
        public void GetBackups_Returns_EmptyList_WhetherOrNotBackUpsFound(string chartType, string positionType, string playername, string sportType, string teamName)
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

            Assert.NotNull(result);
        }

        [Fact]
        public void GetDepthChart()
        {
            var result = nflService.getFullDepthChart();
            Assert.IsAssignableFrom<TeamDepthChart>(result);
        }


        [Theory]
        [InlineData("Offense", "LWR", "Mike Evans", "NFL", "Team1")]
        [InlineData("Offense", "LWR", "Jaelon Darden","NFL", "Team1")]
        [InlineData("Offense", "LWR", "Scott Miller", "NFL", "Team1")]
        public void RemovePlayer_ReturnsPlayer_OnRemoveSuccess(string chartType, string positionType, string playername, string sportType, string teamName)
        {
            RemovePlayerFromDepthChart playertoberemoved = new RemovePlayerFromDepthChart
            {
                ChartType = chartType,
                Name = playername,
                Position = positionType,
                SportType = sportType,
                TeamName = teamName
            };

            var result = nflService.removePlayerFromDepthChart(playertoberemoved);
            Assert.Equal(result.name, playertoberemoved.Name);
        }

        [Theory]
        [InlineData("Offense", "LWR", "Tom", "NFL", "Team1")]
        [InlineData("NONE", "LWR", "Jaelon Darden", "NFL", "Team1")]
        [InlineData("NONE", "LWR", "Jaelon Darden", "NBA", "Team1")]
        [InlineData("Offense", "LWR", "Scott Miller", "NFL", "Team100")]
        [InlineData("Offense", "XYZ", "Jaelon Darden", "NFL", "Team1")]
        public void RemovePlayer_ReturnsEmptyPlayer_WhenPlayerNotFoundOrInvalidInput(string chartType, string positionType, string playername, string sportType, string teamName)
        {
            RemovePlayerFromDepthChart playertoberemoved = new RemovePlayerFromDepthChart
            {
                ChartType = chartType,
                Name = playername,
                Position = positionType,
                SportType = sportType,
                TeamName = teamName
            };

            var result = nflService.removePlayerFromDepthChart(playertoberemoved);
            Assert.Null(result.name);
        }

        

    }
}