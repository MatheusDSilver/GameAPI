using GameAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Infrastructure
{
    public class GameApiDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public GameApiDbContext(DbContextOptions<GameApiDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().OwnsOne(p => p.Stats, stats =>
            {
                stats.Property(s => s.Level).HasColumnName("Stats_Level");
                stats.Property(s => s.Experience).HasColumnName("Stats_Experience");
                stats.Property(s => s.Health).HasColumnName("Stats_Health");
            });
        }
    }
}
