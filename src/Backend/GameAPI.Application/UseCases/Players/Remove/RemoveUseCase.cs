using GameAPI.Application.UseCases.Players.Get;
using GameAPI.Domain;
using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;

namespace GameAPI.Application.UseCases.Players.Remove
{
    public class RemoveUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGetPlayerUseCase _getPlayer;
        private readonly IUnityOfWork _unityOfWork;
        public RemoveUseCase(IPlayerRepository playerRepository, IGetPlayerUseCase getPlayer, 
            IUnityOfWork unityOfWork)
        {
            _playerRepository = playerRepository;
            _getPlayer = getPlayer;
            _unityOfWork = unityOfWork;
        }
        public async Task<Player> Execute(int playerId)
        {
            var player = await _getPlayer.GetById(playerId);

            _playerRepository.Delete(player);

            await _unityOfWork.Commit();

            return player;
        }
    }
}
