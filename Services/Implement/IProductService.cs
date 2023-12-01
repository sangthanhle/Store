using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;


namespace OnlineStore.BusinessLogic.Implement
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task AddProductAsync(ProductDTO product);
        Task UpdateProductAsync(int id, ProductDTO product);
        Task DeleteProductAsync(int id);
        Task SaveChangeAsync();
        Task<(IEnumerable<ProductDTO>, int)> GetPagedAsync(int pageNumber, int pageSize);
       
    }
}


