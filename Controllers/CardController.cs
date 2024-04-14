using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int rows = 10;
            ViewBag.Page = page;
            var cards = await _cardService.GetPaginatedCard(page,rows);
            return View(cards);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CardForCreationDto dto = new CardForCreationDto();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardForCreationDto dto)
        {
            if (dto == null) return NotFound();
            var card = new Card()
            {
                CardNumber = dto.CardNumber,
                CVV = dto.CVV,
                ExpirationDate = dto.ExpirationDate,
                CardHolder = dto.CardHolder,
                Amount = dto.Amount,
                CreatedBy = " ",
            };
            await _cardService.CreateCard(card);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var card = await _cardService.GetCardById(id);
            CardForCreationDto dto = new CardForCreationDto()
            {
                CardNumber = card.CardNumber,
                CardHolder = card.CardHolder,
                Amount = card.Amount,
                ExpirationDate = card.ExpirationDate,
                CVV = card.CVV,
            };
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CardForCreationDto dto)
        {
            
            var card = await _cardService.GetCardById(dto.Id);
            if (dto == null)
            {
                card.CardNumber = dto.CardNumber;
                card.CardHolder = dto.CardHolder;
                card.CVV = dto.CVV;
                card.ExpirationDate = dto.ExpirationDate;
                card.Amount = dto.Amount;
                await _cardService.EditCard(card);
            }
                return RedirectToAction("Index");
            
        }
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _cardService.GetCardById(id);
            await _cardService.DeleteCard(card);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var cardDetails = await _cardService.GetCardById(id);
            return View(cardDetails);
        }
    }
}
