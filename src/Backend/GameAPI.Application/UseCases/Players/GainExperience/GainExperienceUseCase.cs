using GameAPI.Application.UseCases.Players.Get;
using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using GameAPI.Exceptions.ExceptionsBase;
using System.Net.Http.Headers;

namespace GameAPI.Application.UseCases.Players.GainExperience
{
    public class GainExperienceUseCase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGetPlayerUseCase _getPlayer;
        public GainExperienceUseCase(IPlayerRepository playerRepository, IGetPlayerUseCase getPlayer)
        {
            _playerRepository = playerRepository;
            _getPlayer = getPlayer;
        }
        public async Task<Player> Execute(int playerId, int xp)
        {
            Validate(xp);

            var player = await _getPlayer.GetById(playerId);

            player.GainExperience(xp);

            await _playerRepository.UpdateAsync(player);

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
