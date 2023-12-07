using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.DataContext;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;

namespace OnlineStore.DataAccess.Repositories
{
    public class CategoriesRepository : IRepository<Categorie>
    {
        private readonly StoreContext _dbContext;

        public CategoriesRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Categorie entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Categorie>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Categorie> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Categorie>> GetPerPageAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Categories
            .OrderBy(p => p.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _dbContext.Products.CountAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Categorie>> SearchByNameAsync(string name)
        {
            return await _dbContext.Categories
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
        }

        public async Task UpdateAsync(Categorie entity)
        {
            _dbContext.Categories.Update(entity);
            await _dbContext.SaveChangesAsync();
        }


    }
}
