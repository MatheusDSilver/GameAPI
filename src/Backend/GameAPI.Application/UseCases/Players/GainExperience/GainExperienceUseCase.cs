using GameAPI.Application.UseCases.Players.Get;
using GameAPI.Domain;
using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application.UseCases.Players.GainExperience
{
    public class GainExperienceUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGetPlayerUseCase _getPlayer;
        private readonly IUnityOfWork _unityOfWork;
        public GainExperienceUseCase(IPlayerRepository playerRepository, IGetPlayerUseCase getPlayer,
            IUnityOfWork unityOfWork)
        {
            _playerRepository = playerRepository;
            _getPlayer = getPlayer;
            _unityOfWork = unityOfWork;
        }
        public async Task<Player> Execute(int playerId, int xp)
        {
            Validate(xp);

            var player = await _getPlayer.GetById(playerId);

            player.GainExperience(xp);

            _playerRepository.UpdateExperience(player);

            await _unityOfWork.Commit();

            return player;
        }

        private void Validate(int xp)
        {
            var validator = new GainExperienceValidator();
            var result = validator.IsValid(xp);

            if (result == false) throw new ErrorOnValidationException("Need to add more than 0 experience");
        }
    }
}
