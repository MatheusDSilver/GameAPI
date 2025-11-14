using GameAPI.Application;
using GameAPI.Application.UseCases.Players.GainExperience;
using GameAPI.Application.UseCases.Players.Get;
using GameAPI.Application.UseCases.Players.Register;
using GameAPI.Application.UseCases.Players.Remove;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly RegisterPlayerUseCase _registerPlayer;
        private readonly GainExperienceUseCase _gainExperience;
        private readonly RemoveUseCase _remove;
        private readonly GetPlayerUseCase _getPlayer;

        public PlayersController(RegisterPlayerUseCase registerPlayer, RemoveUseCase remove, 
            GetPlayerUseCase getPlayer, GainExperienceUseCase gainExperience)
        {
            _registerPlayer = registerPlayer;
            _remove = remove;
            _getPlayer = getPlayer;
            _gainExperience = gainExperience;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string username)
        {
            var player = await _registerPlayer.Execute(username);
            return Created(string.Empty, player);
            //return CreatedAtAction(nameof(GetById), new { id = player.Id }, player);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _getPlayer.GetById(id);
            return Ok(player);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var player = await _getPlayer.GetAllById();
            return Ok(player);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("{id}/gain-xp")]
        public async Task<IActionResult> GainExperience(int id, [FromQuery] int xp)
        {
            var player = await _gainExperience.Execute(id, xp);
            return Ok(player);
        }

        [HttpDelete("{id}/remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var player = await _remove.Execute(id);
            return Ok(player);
        }
    }
}
