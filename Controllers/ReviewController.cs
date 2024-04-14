using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;
        private readonly IGameServices _gameServices;
        public ReviewController(IReviewServices reviewServices, IGameServices gameServices)
        {
            _reviewServices = reviewServices;
            _gameServices = gameServices;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int rows = 10;
            ViewBag.Page = page;
            var reviews = await _reviewServices.GetPaginatedReviews(page,rows);
            return View(reviews);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ReviewForCreationDto dto = new();
            dto.Games = await _gameServices.GetAllGames();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReviewForCreationDto dto)
        {
            Review review = new()
            {
                ReviewValue = dto.ReviewValue,
                GameId = dto.GameId,
            };
            await _reviewServices.CreateReviewAsync(review);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _reviewServices.GetReviewByIdAsync(id);
            await _reviewServices.DeleteReviewAsync(itemToDelete);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var itemToShowDetails = await _reviewServices.GetReviewByIdAsync(id);
            return View(itemToShowDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var itemToEdit = await _reviewServices.GetReviewByIdAsync(id);
            return View(itemToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Review obj)
        {
            await _reviewServices.EditReviewAsync(obj);
            return RedirectToAction("Index");
        }

    }
}
