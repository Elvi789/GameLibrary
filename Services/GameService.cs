using GameLibrary.Data;
using GameLibrary.Repository;

namespace GameLibrary.Services
{
    public class GameService :IGameServices
    {
        public readonly GameRepository _gameRepo;
        public GameService(GameRepository gameRepo) { _gameRepo = gameRepo; }

        public async Task<Game> GetGameById(int id)
        {
            return await _gameRepo.GetById(id);
        }

        public async Task<List<Game>> GetAllGames()
        {
            return await _gameRepo.GetAll();
        }

        public async Task CreateGame(Game game)
        {
            await _gameRepo.Add(game);
        }

        public async Task EditGame(Game game)
        {
            await _gameRepo.Update(game);

        }

        public async Task DeleteGame(Game game)
        {
            await _gameRepo.Delete(game);
        }
    }
}
