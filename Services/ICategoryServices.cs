using GameLibrary.Data;

namespace GameLibrary.Services
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAllCategoriesAync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoriesAsync(Category category);
        Task DeleteCategoriesAsync(Category category);
    }
}
