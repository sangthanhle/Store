using AutoMapper;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.BusinessLogic.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task AddProductAsync(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await _productRepository.AddAsync(newProduct);
        }

        public async Task UpdateProductAsync(int id, ProductDTO product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return;
            }

            _mapper.Map(product, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);
        }
       
        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct != null)
            {
                await _productRepository.DeleteAsync(id);
                await _productRepository.SaveChangeAsync();
            }
        }
        public async Task SaveChangeAsync()
        {
            await _productRepository.SaveChangeAsync();
        }
        public async Task<(IEnumerable<ProductDTO>, int)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var products = await _productRepository.GetPerPageAsync(pageNumber, pageSize);
            var totalProductCount = await _productRepository.GetTotalCountAsync();

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return (productDTOs, totalProductCount);
        }          
    }
    }

