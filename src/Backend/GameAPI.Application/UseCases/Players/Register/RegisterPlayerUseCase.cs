using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;

namespace GameAPI.Application.UseCases.Players.Register
{
    public class RegisterPlayerUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        public RegisterPlayerUseCase(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<Player> Execute(string name)
        {
            RegisterPlayerValidator.Validator(name);
            var player = new Player(name);
            await _playerRepository.AddPlayerAsync(player);
            return player;
        }
    }
}
