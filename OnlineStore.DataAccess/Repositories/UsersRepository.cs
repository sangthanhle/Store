using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.DataContext;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;

namespace OnlineStore.DataAccess.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        private readonly StoreContext _dbContext;
        public UsersRepository(StoreContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Categorie>> SearchByNameAsync(string name)
        {
            return await _dbContext.Categories
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
        }
    }
}
