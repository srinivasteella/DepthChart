using DepthChart.Models;
using DepthChart.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DepthChart.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class DepthChartController : ControllerBase
    {       

        private readonly ILogger<DepthChartController> _logger;
        IDepthChartService _dservice;
        public DepthChartController(ILogger<DepthChartController> logger, IDepthChartService dservice)
        {
            _logger = logger;
            _dservice = dservice;
        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddPlayerToDepthChart([FromBody] AddPlayer player)
        {
            if (player == null || !ModelState.IsValid) return BadRequest(ModelState);
            Player _player = new Player();
            try
            {
                _player = await _dservice.addPlayerToDepthChart(player);
            }
            catch (AggregateException)
            {
                return BadRequest();//shout/catch/throw/log
            }

            return Ok(_player);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var data = System.IO.File.ReadAllText("NFLDepthChart.json");
        //    NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data);
        //    return Ok(jsonObj);
        //}

        //[HttpPost]       
        //public async Task<IActionResult> Post()
        //{
        //    AddPlayer player = new AddPlayer
        //    {
        //        sportType = SportType.NFL,
        //        position = new C { Player = new Player { Name = "Srini", No = 20 } }
        //    };

        //    var data = System.IO.File.ReadAllText("NFLDepthChart.json");
        //    NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data); // find type of sport
        //    jsonObj.Data.C.Add((C)player.position); // find the type of position and cast //look for exisitng player for same depth
        //    string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        //    System.IO.File.WriteAllText("NFLDepthChart.json", output);
        //    return Ok();
        //}

        //[HttpPost("GetBackup")]
        //public async Task<IActionResult> GetBackups(dynamic input)
        //{
        //    AddPlayer player = new AddPlayer
        //    {
        //        sportType = SportType.NFL,
        //        position = new C { Player = new Player { Name = "Srini", No = 20 } }
        //    };

        //    var data = System.IO.File.ReadAllText("NFLDepthChart.json");
        //    NFL jsonObj = JsonConvert.DeserializeObject<NFL>(data); // find type of sport
        //    var test = jsonObj.Data.QB.Find(a => a.Player.Name.Equals(input));
        //    return Ok();
        //}
    }
}