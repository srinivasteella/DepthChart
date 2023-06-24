using DepthChart.Models;
using DepthChart.Service;
using Microsoft.AspNetCore.Mvc;
using Player = DepthChart.Team.Model.Player;
using TeamPlayer = DepthChart.Models.Player;

namespace DepthChart.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class DepthChartController : ControllerBase
    {       

        IDepthChartService _dservice;
        public DepthChartController(IDepthChartService dservice)
        {
            _dservice = dservice;
        }


        [HttpGet("{sporttype}")]
        public ActionResult GetFullDepthChart(string sporttype)
        {
            if (sporttype == null || !ModelState.IsValid) return BadRequest(ModelState);
            TeamDepthChart teamDepthChart;
            teamDepthChart = _dservice.getFullDepthChart(sporttype);
            return Ok(teamDepthChart);
        }

        [HttpPost("AddPlayer")]
        public ActionResult AddPlayerToDepthChart([FromBody] AddPlayerToDepthChart newplayer)
        {
            if (newplayer == null || !ModelState.IsValid) return BadRequest(ModelState);
            bool isAddPlayerSuccess;
            isAddPlayerSuccess = _dservice.addPlayerToDepthChart(newplayer);
            return Ok(isAddPlayerSuccess);
        }

        [HttpPost("RemovePlayer")]
        public ActionResult<Player> RemovePlayerFromDepthChart([FromBody] RemovePlayerFromDepthChart playertoberemoved)
        {
            if (playertoberemoved == null || !ModelState.IsValid) return BadRequest(ModelState);
            Player player;
            player = _dservice.removePlayerFromDepthChart(playertoberemoved);
            return Ok(player);
        }

        [HttpPost("GetBackup")]
        public ActionResult GetBackUp([FromBody] ChartBackup playerbackup)
        {
            if (playerbackup == null || !ModelState.IsValid) return BadRequest(ModelState);
            IEnumerable<TeamPlayer> teamplayerbackup;
            teamplayerbackup = _dservice.getBackups(playerbackup);
            return Ok(teamplayerbackup);
        }


    }
}