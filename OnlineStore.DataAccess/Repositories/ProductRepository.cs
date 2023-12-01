using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.DataContext;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;

namespace OnlineStore.DataAccess.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly StoreContext _dbContext;
        public ProductRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task AddAsync(Product entity)
        {
            _dbContext.Products.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        // phân trang
        public async Task<IEnumerable<Product>> GetPerPageAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Products
            .OrderBy(p => p.Id) // Sắp xếp theo Id hoặc một trường khác
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _dbContext.Products.CountAsync();
        }

        public  List<Product> GetAll(string searchName, string category)
        {
            IQueryable<Product> query = _dbContext.Set<Product>();

            if (!string.IsNullOrEmpty(searchName))
            {
                // Áp dụng điều kiện tìm kiếm theo tên
                query = query.Where(e => EF.Property<string>(e, "Name").Contains(searchName));
            }

            if (!string.IsNullOrEmpty(category))
            {
                // Áp dụng điều kiện tìm kiếm theo danh mục
                query = query.Where(e => EF.Property<string>(e, "Category").Contains(category));
            }

            return  query.ToList();
        }

        public Task<List<Product>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        // search      


    }
}
