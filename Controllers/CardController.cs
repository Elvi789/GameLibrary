using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardServices _cardServices;
        public CardController(ICardServices cardServices)
        {
            _cardServices = cardServices;
        }
        public async Task<IActionResult> Index()
        {
            var cards = await _cardServices.GetAllCardsAsync();
            return View(cards);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CardForCreationDto dto = new();

            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardForCreationDto dto)
        {
            Card card = new()
            {
                CardHolder = dto.CardHolder,
                CardNumber = dto.CardNumber,
                Cvv = dto.Cvv,
                Balance = dto.Balance,
                ExpireDate = dto.ExpireDate

            };
            await _cardServices.CreateCardAsync(card);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _cardServices.GetCardByIdAsync(id);
            await _cardServices.DeleteCardAsync(itemToDelete);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var itemToShowDetails = await _cardServices.GetCardByIdAsync(id);
            return View(itemToShowDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var itemToEdit = await _cardServices.GetCardByIdAsync(id);
            return View(itemToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Card obj)
        {
            await _cardServices.EditCardAsync(obj);
            return RedirectToAction("Index");
        }
    }
}
