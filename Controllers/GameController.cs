using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GameLibrary.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameServices _gameServices;
        private readonly ICategoryGameServices _categoryGameServices;
        private readonly ICategoryServices _categoryServices;
 
        public GameController(IGameServices gameServices, ICategoryGameServices categoryGameServices, ICategoryServices categoryServices)
        {
            _gameServices = gameServices;
            _categoryGameServices = categoryGameServices;
            _categoryServices = categoryServices;
           
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameServices.GetAllGames();
            return View(games);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            GameForCreationDto game = new GameForCreationDto();
            // Fill the model with categories
            game.Categories = await _categoryServices.GetAllCategoriesAync();
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameForCreationDto dto)
        {
            if (dto == null)
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
                RecommendedRequirements = dto.RecommendedRequirements,
                // nga gjithe userat qe menaxhohen merr userin me id te Userit te loguar
               
            };

            await _gameServices.CreateGame(game);

            if (dto.CategoryIds != null && dto.CategoryIds.Any())
            {
                foreach (var categoryId in dto.CategoryIds)
                {
                    var catGame = new CategoryGame()
                    {
                        GameId = game.Id,
                        CategoryId = categoryId,
                    };

                    await _categoryGameServices.CreateCategoryGameAsync(catGame);
                }
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var itemToShowDetails = await _gameServices.DetailsGameByid(id);


            if (itemToShowDetails == null)
            {
                return NotFound();
            }

            return View(itemToShowDetails);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _gameServices.DetailsGameByid(id);
            var allRelationships = await _categoryGameServices.GetAllCategoryGamesAsync();
            var relationshipsToDelete = allRelationships.Where(x => x.Id == id);
            foreach (var relationship in relationshipsToDelete)
            {
                await _categoryGameServices.DeleteCategoryGameAsync(relationship);
            }



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
            dto.ReleasedDate = DateTime.Now;
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
                game.ReleasedDate = DateTime.Now;
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
