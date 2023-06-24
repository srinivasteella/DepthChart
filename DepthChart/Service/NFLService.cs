using DepthChart.Models;
using DepthChart.Team.Model;
using Newtonsoft.Json;
using Player = DepthChart.Team.Model.Player;
using TeamPlayer = DepthChart.Models.Player;

namespace DepthChart.Service
{
    public interface IService
    {
        bool addPlayerToDepthChart(AddPlayerToDepthChart newplayer);
        Player removePlayerFromDepthChart(RemovePlayerFromDepthChart playertoberemoved);
        IEnumerable<TeamPlayer> getBackups(ChartBackup playerbackup);
        TeamDepthChart getFullDepthChart();


    }
    public interface INFLService : IService { }

    public class NFLService : INFLService
    {
        public NFLDepthChart nflDepthChart;
        public NFLTeam nflTeam;
        public NFLService()
        {
            nflDepthChart = GetNFLDepthChart();
            nflTeam = GetNFLTeam();
        }
        public bool addPlayerToDepthChart(AddPlayerToDepthChart newplayer)
        {
            Player _player = GetPlayerByName(newplayer.Name, newplayer.TeamName);
            if (_player == null) return false;

            Position _position = getPlayerPosition(newplayer);

            if (_position == null) return false;

            int index = CheckIfPlayerAlreadyPresent(_position, _player.name);

            if (index == -1)
            {
                if (CheckIfTheDepthIsEqualorMoreThanRequestedDepth(_position, newplayer.Depth))
                    AddPlayer(_player, newplayer);
                else
                    InsertPlayer(newplayer.Depth, _player, newplayer);
            }
            else
            {
                if (!CheckIfThePlayerDepthAndRequestedDepthSame(index, newplayer.Depth))
                {
                    RemovePlayer(index, newplayer);
                    if (CheckIfTheDepthIsEqualorMoreThanRequestedDepth(_position, newplayer.Depth))
                        AddPlayer(_player, newplayer);
                    else
                        InsertPlayer(newplayer.Depth, _player, newplayer);
                }
            }
            return true;
        }

        public IEnumerable<TeamPlayer> getBackups(ChartBackup playerbackup)
        {
            Player _player = GetPlayerByName(playerbackup.Name, playerbackup.TeamName);
            if (_player == null) return new List<TeamPlayer>();

            Position _position = getPlayerPosition(playerbackup);

            if (_position == null) return new List<TeamPlayer>();

            int index = CheckIfPlayerAlreadyPresent(_position, _player.name);
            if (index != -1)
            {
                return _position.Players.Skip(index + 1);
            }
            return new List<TeamPlayer>();
        }

        public TeamDepthChart getFullDepthChart()
        {
            return GetNFLDepthChart();
        }

        public Player removePlayerFromDepthChart(RemovePlayerFromDepthChart playertoberemoved)
        {
            Player _player = GetPlayerByName(playertoberemoved.Name, playertoberemoved.TeamName);
            if (_player == null) return new Player();

            Position _position = getPlayerPosition(playertoberemoved);

            if (_position == null) return new Player();

            int index = CheckIfPlayerAlreadyPresent(_position, _player.name);

            if (index != -1)
            {
                RemovePlayer(index, playertoberemoved);
                SaveChanges();
                return _player;
            }
            return new Player();
        }

        public Position? getPlayerPosition(DepthChartOpsInput input)
        {
            return nflDepthChart.Teams.Find(t => t.TeamName.Equals(input.TeamName, StringComparison.OrdinalIgnoreCase))?.DepthCharts.Find(d => d.ChartType.Equals(input.ChartType, StringComparison.OrdinalIgnoreCase))
                ?.Position.Find(p => p.Type.Equals(input.Position, StringComparison.OrdinalIgnoreCase));
        }

        private bool CheckIfTheDepthIsEqualorMoreThanRequestedDepth(Position position, int depth)
        {

            if (position.Players.Count <= depth)
                return true;
            else
                return false;
        }

        private bool CheckIfThePlayerDepthAndRequestedDepthSame(int currentDepth, int requestedDepth)
        {
            if (currentDepth == requestedDepth)
                return true;
            else
                return false;
        }

        private bool AddPlayer(Player player, AddPlayerToDepthChart newplayer)
        {
            try
            {
                nflDepthChart.Teams.Find(t => t.TeamName.Equals(newplayer.TeamName, StringComparison.OrdinalIgnoreCase))?.DepthCharts.Find(d => d.ChartType.Equals(newplayer.ChartType, StringComparison.OrdinalIgnoreCase))
                ?.Position.Find(p => p.Type.Equals(newplayer.Position, StringComparison.OrdinalIgnoreCase))?.Players.Add(new TeamPlayer { name = player.name, number = player.number });
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool InsertPlayer(int index, Player player, AddPlayerToDepthChart newplayer)
        {
            try
            {
                nflDepthChart.Teams.Find(t => t.TeamName.Equals(newplayer.TeamName, StringComparison.OrdinalIgnoreCase))?.DepthCharts.Find(d => d.ChartType.Equals(newplayer.ChartType, StringComparison.OrdinalIgnoreCase))
               ?.Position.Find(p => p.Type.Equals(newplayer.Position, StringComparison.OrdinalIgnoreCase))?.Players.Insert(index, new TeamPlayer { name = player.name, number = player.number });
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool RemovePlayer(int index, DepthChartOpsInput input)
        {
            try
            {
                nflDepthChart.Teams.Find(t => t.TeamName.Equals(input.TeamName, StringComparison.OrdinalIgnoreCase))?.DepthCharts.Find(d => d.ChartType.Equals(input.ChartType, StringComparison.OrdinalIgnoreCase))
              ?.Position.Find(p => p.Type.Equals(input.Position, StringComparison.OrdinalIgnoreCase))?.Players.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Player? GetPlayerByName(string name, string teamname)
        {
            return nflTeam.Teams.Find(f => f.TeamName.Equals(teamname, StringComparison.OrdinalIgnoreCase))?.players.FirstOrDefault(p => p.name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        private void SaveChanges()
        {
            string output = JsonConvert.SerializeObject(nflDepthChart, Formatting.Indented);
            File.WriteAllText("NFLDepthChart.json", output);
        }


        private int CheckIfPlayerAlreadyPresent(Position position, string playerName)
        {
            return position.Players.FindIndex(p => p.name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        }

        private NFLDepthChart GetNFLDepthChart()
        {
            return JsonConvert.DeserializeObject<NFLDepthChart>(File.ReadAllText("NFLDepthChart.json"));
        }

        private NFLTeam GetNFLTeam()
        {
            return JsonConvert.DeserializeObject<NFLTeam>(File.ReadAllText("NFLPlayers.json"));
        }
    }
}
