using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.Get
{
    public class GetPlayerUseCase : IGetPlayerUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        public GetPlayerUseCase(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<Player> GetById(int playerId)
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            return player is null ? throw new ErrorOnValidationException("Id not existing") : player;
        }

        public async Task<IList<Player>> GetAllById()
        {
            var player = await _playerRepository.GetAllByIdAsync();
            return player is null ? throw new ErrorOnValidationException("Not exist any player") : player;
        }
    }
}
