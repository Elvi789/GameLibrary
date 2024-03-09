using GameLibrary.Data;

namespace GameLibrary.Services
{
    public interface IGameServices
    {
        Task<Game> GetGameById(int id);
        Task<List<Game>> GetAllGames();
        Task CreateGame(Game game);
        Task EditGame(Game game); 
        Task DeleteGame(Game game);
        Task<Game> DetailsGameByid(int id);
    }
}
