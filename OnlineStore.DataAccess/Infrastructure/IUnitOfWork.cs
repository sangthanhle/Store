using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Data;

namespace OnlineStore.DataAccess.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
      
        Task<int> SaveChangesAsync();
    }
}
