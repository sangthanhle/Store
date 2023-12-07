using AutoMapper;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.BusinessLogic.Service
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Categorie> _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService(IRepository<Categorie> categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }
        public async Task AddCategoryAsync(CategorieDTO category)
        {
            var newCategory = _mapper.Map<Categorie>(category);
            await _categoriesRepository.AddAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var existingCategory = await _categoriesRepository.GetByIdAsync(categoryId);
            if (existingCategory != null)
            {
                await _categoriesRepository.DeleteAsync(categoryId);
                await _categoriesRepository.SaveChangeAsync();
            }
        }

        public async Task<IEnumerable<CategorieDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoriesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategorieDTO>>(categories);
        }

        public async Task<CategorieDTO> GetCategoryByIdAsync(int categoryId)
        {
            var categories = await _categoriesRepository.GetByIdAsync(categoryId);
            return _mapper.Map<CategorieDTO>(categories);
        }

        public async Task<(IEnumerable<CategorieDTO>, int)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var categories = await _categoriesRepository.GetPerPageAsync(pageNumber, pageSize);
            var totalCategoryCount = await _categoriesRepository.GetTotalCountAsync();

            var CategorieDTOs = _mapper.Map<IEnumerable<CategorieDTO>>(categories);

            return (CategorieDTOs, totalCategoryCount);
        }

        public async Task SaveChangeAsync()
        {
            await _categoriesRepository.SaveChangeAsync();
        }

      

        public async Task UpdateCategoryAsync(int categoryId, CategorieDTO category)
        {
            var existingCategory = await _categoriesRepository.GetByIdAsync(categoryId);
            if (existingCategory == null)
            {
                return;
            }

            _mapper.Map(category, existingCategory);
            await _categoriesRepository.UpdateAsync(existingCategory);
        }
        // tim kiem
        public async Task<List<CategorieDTO>> SearchCategoriesByNameAsync(string name)
        {
            var categories = await _categoriesRepository.SearchByNameAsync(name);
            var categoriesDTO = _mapper.Map<List<CategorieDTO>>(categories);
            return categoriesDTO;
        }
    }
}
