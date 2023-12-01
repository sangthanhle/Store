using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Infrastructure
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly StoreContext _dataContext;
        
        public BaseRepository(StoreContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
            await SaveChangeAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dataContext.Set<TEntity>().Remove(entity);
                await SaveChangeAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPerPageAsync(int pageNumber, int pageSize)
        {
            return await _dataContext.Set<TEntity>()
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _dataContext.Set<TEntity>().CountAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public Task<List<TEntity>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await SaveChangeAsync();
        }
    }
}


