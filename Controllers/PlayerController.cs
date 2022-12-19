using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using code.Services;
using code.Models;

namespace code.Controllers
{

    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
    
        private readonly ILogger<PlayerController> _logger;
        private readonly PlayerService _playerService;


        public PlayerController(
            ILogger<PlayerController> logger,
            PlayerService characterService)
        {
            _logger = logger;
            _playerService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Players>>> GetPlayers()
        {
            var players = await _playerService.GetPlayers();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetPlayer(Guid id)
        {
            var player = await _playerService.GetPlayer(id);
            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreatePlayer(Players players)
        {

            var player = await _playerService.Create(players);


            return Created(player);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<object>> UpdatePlayer(Guid id, Players players)
        {
            var player = await _playerService.Update(id, players);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeletePlayer(Guid id)
        {
            var player = await _playerService.Delete(id);
            return NoContent();
        }


        private ObjectResult Created(object value)
        {
            return StatusCode(201, value);
        }
    }

   
}