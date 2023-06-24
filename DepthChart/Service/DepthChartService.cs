using DepthChart.Models;

namespace DepthChart.Service
{
    public interface IDepthChartService
    {
        bool addPlayerToDepthChart(AddPlayerToDepthChart player);
        //Task<Player> removePlayerFromDepthChart(AddPlayer position);
        //Task<Player> getBackups(AddPlayer position);
        //Task<IEnumerable<Data>> getFullDepthChart();
    }

    public class DepthChartService : IDepthChartService
    {
        INFLService _nflService;
        Dictionary<SportType, IService> sportServiceDict = new Dictionary<SportType, IService>();
        public DepthChartService(INFLService nflSerivce)
        {
            _nflService = nflSerivce;
            sportServiceDict.Add(SportType.NFL, _nflService);

        }
        public bool addPlayerToDepthChart(AddPlayerToDepthChart player)
        {
            try
            {
                SportType _sportType = GetSportType(player.SportType);
                PositionType _positionType = GetPositionType(player.Position);
                if (_sportType != null && _positionType != null)
                    return sportServiceDict.ContainsKey(_sportType) ? sportServiceDict[_sportType].addPlayerToDepthChart(player) : throw new NotImplementedException();

                else throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //public Task<Player> getBackups(AddPlayer position)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Data>> getFullDepthChart()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Player> removePlayerFromDepthChart(AddPlayer position)
        //{
        //    throw new NotImplementedException();
        //}

        public SportType GetSportType(string sportType)
        {
            SportType enumName;
            Enum.TryParse(sportType, true, out enumName);
            return enumName;
        }

        public PositionType GetPositionType(string positionType)
        {
            PositionType enumName;
            Enum.TryParse(positionType, true, out enumName);
            return enumName;
        }
    }
}
