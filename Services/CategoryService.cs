using GameLibrary.Data;
using GameLibrary.Repository;

namespace GameLibrary.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly CategoryRepository _catRepo;
        public CategoryService(CategoryRepository categoryRepository) { _catRepo =  categoryRepository; }

        public async Task<List<Category>> GetAllCategoriesAync()
        {
           return  await _catRepo.GetAll();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _catRepo.GetById(id);
        }
        public async Task CreateCategoryAsync(Category category)
        {
            await _catRepo.Add(category);
        }
        public async Task UpdateCategoriesAsync(Category category)
        {
            await _catRepo.Update(category);
        }
        public async Task DeleteCategoriesAsync(Category category)
        {
            await _catRepo.Delete(category);
        }

        public async Task<Category> DetailsCategoryByid(int id)
        {
            return await _catRepo.GameCategoryDetailsByIdAsync(id);
        }
    }
}
