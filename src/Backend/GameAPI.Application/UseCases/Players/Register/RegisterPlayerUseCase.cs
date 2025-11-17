using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using GameAPI.Exceptions.ExceptionsBase;
using System.Net.Http.Headers;

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
            Validate(name);

            var player = new Player(name);
            await _playerRepository.AddPlayerAsync(player);
            return player;
        }

        private void Validate(string name)
        {
            var validator = new RegisterPlayerValidator();
            var result = validator.IsValid(name);

            if (result == false) throw new ErrorOnValidationException("Name cannot be empty");
        }
    }
}
