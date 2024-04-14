using GameLibrary.Data;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Services
{
    public interface ICategoryServices
    {
        Task<PaginatedList<Category>> GetPaginatedCategories(int page = 1, int pageSize = 10);
        Task<List<Category>> GetAllCategoriesAync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoriesAsync(Category category);
        Task DeleteCategoriesAsync(Category category);
        Task<Category> DetailsCategoryByid(int id);
    }
}
