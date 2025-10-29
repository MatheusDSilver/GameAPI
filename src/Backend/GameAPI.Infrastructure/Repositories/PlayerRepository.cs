using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GameApiDbContext _context;

        public PlayerRepository(GameApiDbContext context)
        {
            _context = context;
        }

        public async Task AddPlayerAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(a => a.Id == id);
            return player!;
        }

        public async Task UpdateAsync(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Player>> GetAllByIdAsync()
        {
            var player = await _context.Players.ToListAsync();
            return player;
        }
    }
}