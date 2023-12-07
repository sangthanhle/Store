

using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.DataContext;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;

namespace OnlineStore.DataAccess.Repositories
{
    public class StockRepository:BaseRepository<Stock>
    {
        private readonly StoreContext _dbContext;
        public StockRepository(StoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<List<Stock>> SearchByNameAsync(string name)
        //{
        //    return await _dbContext.Stocks
        //    .Where(c => c.Name.Contains(name))
        //    .ToListAsync();
        //}
    }
}
