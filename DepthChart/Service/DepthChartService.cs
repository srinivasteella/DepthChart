using DepthChart.Models;
using Newtonsoft.Json.Linq;

namespace DepthChart.Service
{
    public interface IDepthChartService
    {
        Task<Player> addPlayerToDepthChart(AddPlayer position);
        Task<Player> removePlayerFromDepthChart(AddPlayer position);
        Task<Player> getBackups(AddPlayer position);
        Task<IEnumerable<Data>> getFullDepthChart();
    }

    public class DepthChartService : IDepthChartService
    {
        IPositionConverter _positionConverter;
        ISportConverter _sportConverter;

        INFLService _nflService;
        Dictionary<SportType, IService> sportServiceDict = new Dictionary<SportType, IService>();
        public DepthChartService(IPositionConverter positionConverter,INFLService nflSerivce,ISportConverter sportConverter)
        {
            _positionConverter = positionConverter;
            _nflService = nflSerivce;
            _sportConverter = sportConverter;
            sportServiceDict.Add(SportType.NFL, _nflService);

        }
        public async Task<Player> addPlayerToDepthChart(AddPlayer player)
        {
            try
            {
                Position _position = _positionConverter.Convert(player);
                if (_position != null)
                    return sportServiceDict.ContainsKey(player.sportType) ? await sportServiceDict[player.sportType].addPlayerToDepthChart(_position) : throw new NotImplementedException();

                else throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public Task<Player> getBackups(AddPlayer position)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Data>> getFullDepthChart()
        {
            throw new NotImplementedException();
        }

        public Task<Player> removePlayerFromDepthChart(AddPlayer position)
        {
            throw new NotImplementedException();
        }

    }
}
