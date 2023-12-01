using OnlineStore.Domain.DTO;


namespace OnlineStore.BusinessLogic.Implement
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategorieDTO>> GetAllCategoriesAsync();
        Task<CategorieDTO> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(CategorieDTO category);
        Task UpdateCategoryAsync(int categoryId, CategorieDTO category);
        Task DeleteCategoryAsync(int categoryId);
        Task SaveChangeAsync();
        Task<(IEnumerable<CategorieDTO>, int)> GetPagedAsync(int pageNumber, int pageSize);
        Task<List<CategorieDTO>> SearchCategoriesByNameAsync(string name);
    }
}
