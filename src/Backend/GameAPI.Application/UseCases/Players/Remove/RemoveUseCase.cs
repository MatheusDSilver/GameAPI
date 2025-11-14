using GameAPI.Application.UseCases.Players.Get;
using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;

namespace GameAPI.Application.UseCases.Players.Remove
{
    public class RemoveUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGetPlayerUseCase _getPlayer;
        public RemoveUseCase(IPlayerRepository playerRepository, IGetPlayerUseCase getPlayer)
        {
            _playerRepository = playerRepository;
            _getPlayer = getPlayer;
        }
        public async Task<Player> Execute(int playerId)
        {
            var player = await _getPlayer.GetById(playerId);

            await _playerRepository.DeleteAsync(player);

            return player;
        }
    }
}
