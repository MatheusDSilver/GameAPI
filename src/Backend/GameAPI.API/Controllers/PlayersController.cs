using GameAPI.Application;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string username)
        {
            var player = await _playerService.CreatePlayerAsync(username);
            return Created(string.Empty, player);
            //return CreatedAtAction(nameof(GetById), new { id = player.Id }, player);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetById(id);
            return Ok(player);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var player = await _playerService.GetAllById();
            return Ok(player);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("{id}/gain-xp")]
        public async Task<IActionResult> GainExperience(int id, [FromQuery] int xp)
        {
            var player = await _playerService.AddExperienceAsync(id, xp);
            return Ok(player);
        }

        [HttpDelete("{id}/remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var player = await _playerService.RemovePlayer(id);
            return Ok(player);
        }
    }
}
