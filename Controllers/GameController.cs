using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameServices _gameServices;
        public GameController(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }

        public async Task<IActionResult >Index()
        {
            var games = await _gameServices.GetAllGames();
            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            GameForCreationDto game = new GameForCreationDto();

            return View(game);
        }


        [HttpPost]
        public async Task<IActionResult> Create(GameForCreationDto dto)
        {
           if(dto == null)
            {
                return NotFound();
            }

            Game game = new Game
            {
                Title = dto.Title,
                
                Price = dto.Price,
                Description = dto.Description,
                ReleasedDate = dto.ReleasedDate,
                RequiredAge = dto.RequiredAge,
                MinimumRequirements = dto.MinimumRequirements,
                RecommendedRequirements = dto.RecommendedRequirements
            };

            await _gameServices.CreateGame(game);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var itemToShowDetails = await _gameServices.GetGameById(id);


            if (itemToShowDetails == null)
            {
                return NotFound();
            }

            return View(itemToShowDetails);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _gameServices.GetGameById(id);
           


            await _gameServices.DeleteGame(itemToDelete);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GameForCreationDto dto = new GameForCreationDto();
            var game = await _gameServices.GetGameById(id);
            
            dto.RecommendedRequirements = game.RecommendedRequirements;
            dto.MinimumRequirements = game.MinimumRequirements;
            dto.Title = game.Title;
            dto.Description = game.Description;
            dto.Price = game.Price;
            dto.Id = game.Id;
            dto.RequiredAge = game.RequiredAge;
            dto.ReleasedDate = DateTime.Today;
            dto.Description = game.Description;

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameForCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var game = await _gameServices.GetGameById(dto.Id);
            if (game != null)
            {
                game.Title = dto.Title;
                game.Price = dto.Price;
                game.Description = dto.Description;
                game.ReleasedDate = DateTime.Today;
                game.RequiredAge = dto.RequiredAge;
                game.MinimumRequirements = dto.MinimumRequirements;
                game.RecommendedRequirements = dto.RecommendedRequirements;

                await _gameServices.EditGame(game);
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<bool> ChangeIsForSale(int id)
        {
            var gameToChangeSale = await _gameServices.GetGameById(id);
            if (gameToChangeSale != null)
            {
                gameToChangeSale.IsForSale = !gameToChangeSale.IsForSale;
                await _gameServices.EditGame(gameToChangeSale);
                return true;
            }
            return false;
        }
    }
}
