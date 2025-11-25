using GameAPI.Domain;
using Microsoft.IdentityModel.Tokens;

namespace GameAPI.Infrastructure
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly GameApiDbContext _dbContext;

        public UnityOfWork(GameApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
