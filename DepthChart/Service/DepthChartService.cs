using DepthChart.Models;
using Player = DepthChart.Team.Model.Player;
using TeamPlayer = DepthChart.Models.Player;
namespace DepthChart.Service
{
    public interface IDepthChartService
    {
        bool addPlayerToDepthChart(AddPlayerToDepthChart player);
        Player removePlayerFromDepthChart(RemovePlayerFromDepthChart playertoberemoved);
        IEnumerable<TeamPlayer> getBackups(ChartBackup playerbackup);
        TeamDepthChart getFullDepthChart(string sporttype);
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
                if (_sportType != SportType.NONE && _positionType != PositionType.NONE)
                    return sportServiceDict.ContainsKey(_sportType) ? sportServiceDict[_sportType].addPlayerToDepthChart(player) : false;                
            }
            catch  { /*log exception*/ }
            return false;
        }

       

        public Player removePlayerFromDepthChart(RemovePlayerFromDepthChart playertoberemoved)
        {
            try
            {
                SportType _sportType = GetSportType(playertoberemoved.SportType);
                PositionType _positionType = GetPositionType(playertoberemoved.Position);
                if (_sportType != SportType.NONE && _positionType != PositionType.NONE)
                    return sportServiceDict.ContainsKey(_sportType) ? sportServiceDict[_sportType].removePlayerFromDepthChart(playertoberemoved) : new Player();               
            }
            catch { /*log exception*/ }
            return new Player();
        }

        public IEnumerable<TeamPlayer> getBackups(ChartBackup playerbackup)
        {
            try
            {
                SportType _sportType = GetSportType(playerbackup.SportType);
                PositionType _positionType = GetPositionType(playerbackup.Position);
                if (_sportType != SportType.NONE && _positionType != PositionType.NONE)
                    return sportServiceDict.ContainsKey(_sportType) ? sportServiceDict[_sportType].getBackups(playerbackup) : new List<TeamPlayer>();
            }
            catch { /*log exception*/ }
            return new List<TeamPlayer>();
        }

        public TeamDepthChart getFullDepthChart(string sporttype)
        {
            try
            {
                SportType _sportType = GetSportType(sporttype);
                if (_sportType != SportType.NONE)
                    return sportServiceDict.ContainsKey(_sportType) ? sportServiceDict[_sportType].getFullDepthChart() : new TeamDepthChart();
            }
            catch { /*log exception*/ }
            return new TeamDepthChart();
        }

        private SportType GetSportType(string sportType)
        {
            SportType enumName;
            Enum.TryParse(sportType, true, out enumName);
            return enumName;
        }

        private PositionType GetPositionType(string positionType)
        {
            PositionType enumName;
            Enum.TryParse(positionType, true, out enumName);
            return enumName;
        }
    }
}
