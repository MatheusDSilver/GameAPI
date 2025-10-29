using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using GameAPI.Exceptions.ExceptionsBase;

namespace GameAPI.Application
{
    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> CreatePlayerAsync(string name)
        {
            CreatePlayerValidation(name);
            var player = new Player(name);
            await _playerRepository.AddPlayerAsync(player);
            return player;
        }

        public async Task<Player> AddExperienceAsync(int playerId, int xp)
        {
            ExperienceValidation(xp);
            var player = await GetById(playerId);
            player.GainExperience(xp);
            await _playerRepository.UpdateAsync(player);
            return player;
        }

        public async Task<Player> RemovePlayer(int playerId)
        {
            var player = await GetById(playerId);
            await _playerRepository.DeleteAsync(player);
            return player;
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

        private void ExperienceValidation(int xp)
        {
            if (xp < 1) throw new ErrorOnValidationException("Need to add more than 0 experience");
        }

        private void CreatePlayerValidation(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ErrorOnValidationException("Name cannot be empty");
        }

    }
}
