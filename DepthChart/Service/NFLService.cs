using DepthChart.Models;
using Newtonsoft.Json;

namespace DepthChart.Service
{
    public interface IService
    {
        Task<Player> addPlayerToDepthChart(Position position);
        Task<Player> removePlayerFromDepthChart(Position position);
        Task<Player> getBackups(Position position);
        Task<IEnumerable<Data>> getFullDepthChart();


    }
    public interface INFLService : IService { }

    public class NFLService : INFLService
    {
        public NFLService()
        {

        }
        public Task<Player> addPlayerToDepthChart(Position position)
        {
            NFL nflDepthChart = GetDepthChart();
            var result = nflDepthChart.Data.GetType().GetProperty(position.PositionType.ToString());
            throw new NotImplementedException();

        }

        public Task<Player> getBackups(Position position)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Data>> getFullDepthChart()
        {
            throw new NotImplementedException();
        }

        public Task<Player> removePlayerFromDepthChart(Position position)
        {
            throw new NotImplementedException();
        }

        private NFL GetDepthChart()
        {
            return JsonConvert.DeserializeObject<NFL>(File.ReadAllText("NFLDepthChart.json"));
        }
    }
}
