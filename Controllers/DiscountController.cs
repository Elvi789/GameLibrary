using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;


namespace GameLibrary.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountServices _discountServices;
        private readonly IGameServices _gameServices;
        public DiscountController(IDiscountServices discountServices, IGameServices gameServices)
        {
            _discountServices = discountServices;
            _gameServices = gameServices;
        }
        public async Task<IActionResult> Index(int page =1)
        {
            int rows = 10;
            ViewBag.Page = page;
            IEnumerable<Discount> discounts = await _discountServices.GetPaginatedDiscounts(page, rows);
            return View(discounts);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            DiscountForCreationDto dto = new();
            dto.Games = await _gameServices.GetAllGames();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DiscountForCreationDto dto)
        {
            Discount discount = new()
            {
                Code = dto.Code,
                Usages = dto.Usages,
                Amount = dto.Amount,
                IsFixedAmount = dto.IsFixedAmount,
                PercentageAmount = dto.PercentageAmount,
                IsPercentage = dto.IsPercentage,
                GameId = dto.GameId,
            };

            await _discountServices.CreateDiscountAsync(discount);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _discountServices.GetDiscountByIdAsync(id);
            await _discountServices.DeleteDiscountAsync(itemToDelete);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details (int id)
        {
            var itemToShowDetails = await _discountServices.GetDiscountByIdAsync(id);
            return View(itemToShowDetails); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var itemToEdit = await _discountServices.GetDiscountByIdAsync(id);
            return View(itemToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Discount obj)
        {
            await _discountServices.EditDiscountAsync(obj);
            return RedirectToAction("Index");
        }
       
    }
}

