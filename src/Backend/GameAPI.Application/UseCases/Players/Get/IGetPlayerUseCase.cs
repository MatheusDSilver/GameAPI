using GameAPI.Domain.Entities;

namespace GameAPI.Application.UseCases.Players.Get
{
    public interface IGetPlayerUseCase
    {
        public Task<Player> GetById(int playerId);
    }
}
