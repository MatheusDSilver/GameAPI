using GameAPI.Domain.Entities;

namespace GameAPI.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> GetByIdAsync(int id);
        Task<IList<Player>> GetAllByIdAsync();
        Task AddPlayerAsync(Player player);
        Task UpdateAsync(Player player);
        Task DeleteAsync(Player player);
    }
}
