using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.DataAccess.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task SaveChangeAsync();
        Task<IEnumerable<TEntity>> GetPerPageAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
        Task<List<TEntity>> SearchByNameAsync(string name);

    }
}


