using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;


namespace GameLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _catservices;
        private readonly IGameServices _gameServices;
        private readonly ICategoryGameServices _categoryGameServices;
        public CategoryController(ICategoryServices catservices, ICategoryGameServices categoryGameServices, IGameServices gameServices)
        {
            _catservices = catservices;
            _categoryGameServices = categoryGameServices;
            _gameServices = gameServices; 
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _catservices.GetAllCategoriesAync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CategoryForCreationDto categoryForCreationDto = new CategoryForCreationDto();
            categoryForCreationDto.Games = await _gameServices.GetAllGames();
            return View(categoryForCreationDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CategoryForCreationDto dto)
        {
            Category category = new Category()
            { 
                Name = dto.Name,
                Description = dto.Description
            };
               
            await _catservices.CreateCategoryAsync(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _catservices.DetailsCategoryByid(id);

            var allRelationships = await _categoryGameServices.GetAllCategoryGamesAsync();



            if (itemToDelete.CategoryGames != null && itemToDelete.CategoryGames.Any())
            {
                return RedirectToAction("Index");
            }
            else if (itemToDelete.CategoryGames == null || itemToDelete.CategoryGames.Count == 0 || itemToDelete.CategoryGames.All(x => x == null))
            {
                await _catservices.DeleteCategoriesAsync(itemToDelete);


                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _catservices.DetailsCategoryByid(id);
            return View(category);
        }
         
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _catservices.GetCategoryByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            await _catservices.UpdateCategoriesAsync(obj);
            return RedirectToAction("Index");
        }
    }
}
