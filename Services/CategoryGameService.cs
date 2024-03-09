using GameLibrary.Data;
using GameLibrary.Repository;

namespace GameLibrary.Services
{
    public class CategoryGameService : ICategoryGameServices
    {
        private readonly CategoryGameRepository _catGameRepository;

        public CategoryGameService(CategoryGameRepository catGameRepository)
        {
            _catGameRepository = catGameRepository;
        }

        public async Task<List<CategoryGame>> GetAllCategoryGamesAsync()
        {
            return await _catGameRepository.GetAll();
        }

        public async Task<CategoryGame> GetCategoryGameByIdAsync(int id)
        {
            return await _catGameRepository.GetById(id);
        }

        public async Task CreateCategoryGameAsync(CategoryGame categoryGame)
        {
            await _catGameRepository.Add(categoryGame);
        }

        public async Task DeleteCategoryGameAsync(CategoryGame categoryGame)
        {
            await _catGameRepository.Delete(categoryGame);  
        }
        public async Task UpdateCategoryGameAsync(CategoryGame categoryGame)
        {
            await _catGameRepository.Update(categoryGame);
        }
    }
}
