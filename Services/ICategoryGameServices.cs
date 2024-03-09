using GameLibrary.Data;

namespace GameLibrary.Services
{
    public interface ICategoryGameServices
    {
        Task<List<CategoryGame>> GetAllCategoryGamesAsync();
        Task<CategoryGame> GetCategoryGameByIdAsync(int id);
        Task CreateCategoryGameAsync(CategoryGame categoryGame);
        Task DeleteCategoryGameAsync(CategoryGame categoryGame);
        Task UpdateCategoryGameAsync(CategoryGame categoryGame);
    }
}