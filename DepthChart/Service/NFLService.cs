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
        NFL nflDepthChart;
        public NFLService()
        {
            nflDepthChart = GetDepthChart();
        }
        public Task<Player> addPlayerToDepthChart(Position position)
        {
            //var result = nflDepthChart.Data.GetType().GetProperty(position.PositionType.ToString());
            int index = CheckIfPlayerAlreadyPresent(nflDepthChart.Data.LWR,position.Player.Name);
            if (index == -1) AddPlayer(position);
            else InsertPlayer(index,position);
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

        private bool AddPlayer(Position position)
        {
            try
            {
                nflDepthChart.Data.LWR.Add((LWR)position);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool InsertPlayer(int index, Position position)
        {
            try
            {
                nflDepthChart.Data.LWR.Insert(index,(LWR)position);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool RemovePlayer(int index)
        {
            try
            {
                nflDepthChart.Data.LWR.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SaveChanges()
        {
            string output = JsonConvert.SerializeObject(nflDepthChart, Formatting.Indented);
            File.WriteAllText("NFLDepthChart.json", output);
        }


        private int CheckIfPlayerAlreadyPresent(List<LWR> data,string playerName)
        {
            int index = data.FindIndex(a => a.Player.Name == playerName);
            return index;
        }

        private NFL GetDepthChart()
        {
            return JsonConvert.DeserializeObject<NFL>(File.ReadAllText("NFLDepthChart.json"));
        }
    }
}
