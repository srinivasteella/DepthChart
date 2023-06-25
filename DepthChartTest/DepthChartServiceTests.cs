using DepthChart.Models;
using DepthChart.Service;
using Moq;
namespace DepthChartTest
{
    public class DepthChartServiceTests
    {
        Mock<INFLService> moqNFLService;
        AddPlayerToDepthChart player;

        public DepthChartServiceTests()
        {
            moqNFLService = new Mock<INFLService>();
            player = new AddPlayerToDepthChart
            {
                ChartType = "offense",
                Depth = 0,
                Name = "Mike",
                Position = "LWR",
                SportType = "NFL",
                TeamName = "Team1"
            };
        }

        [Fact]
        public void AddPlayerToDepthChart_WhenSportandPositionTypeImplementationFound_RespectiveSportServiceCalledOnce()
        {
            //given
            var sut = new DepthChartService(moqNFLService.Object);

            //when
            var result = sut.addPlayerToDepthChart(player);

            //then
            moqNFLService.Verify(x => x.addPlayerToDepthChart(player), Times.Once);
        }

        [Fact]
        public void AddPlayerToDepthChart_WhenSportTypeNotImplemented_RespectiveSportServiceNotCalled()
        {
            player.SportType = "NBA";
            //given
            var sut = new DepthChartService(moqNFLService.Object);

            //when
            var result = sut.addPlayerToDepthChart(player);

            //then
            moqNFLService.Verify(x => x.addPlayerToDepthChart(player), Times.Never);
        }

        [Fact]
        public void AddPlayerToDepthChart_WhenPositionNotFound_RespectiveSportServiceNotCalled()
        {
            player.Position = "XYZ";
            //given
            var sut = new DepthChartService(moqNFLService.Object);

            //when
            var result = sut.addPlayerToDepthChart(player);

            //then
            moqNFLService.Verify(x => x.addPlayerToDepthChart(player), Times.Never);
        }
        [Fact]
        public void AddPlayerToDepthChart_WhenPositionFound_RespectiveSportServiceNotCalled()
        {
            player.Position = "RG";
            //given
            var sut = new DepthChartService(moqNFLService.Object);

            //when
            var result = sut.addPlayerToDepthChart(player);

            //then
            moqNFLService.Verify(x => x.addPlayerToDepthChart(player), Times.Once);
        }


    }
}
