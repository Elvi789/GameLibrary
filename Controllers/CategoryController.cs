using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace GameLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _catservices;
        public CategoryController(ICategoryServices catservices)
        {
            _catservices = catservices;
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
            var itemToDelete = await _catservices.GetCategoryByIdAsync(id);
            await _catservices.DeleteCategoriesAsync(itemToDelete);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _catservices.GetCategoryByIdAsync(id);
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
