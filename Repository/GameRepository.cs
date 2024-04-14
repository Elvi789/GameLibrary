using GameLibrary.Data;
using GameLibrary.Repository.Pagination;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Repository
{
    public class GameRepository: BaseRepository<Game>
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Game>> GetPaginatedGame(string emri, int page = 1, int pageSize = 10)
        {
            var gameResult = _context.Games.OrderByDescending(x => x.Id).AsQueryable();
           
            if (!string.IsNullOrEmpty(emri))
            {
                gameResult = _context.Games.Where(x => x.Title == emri);
            }
            var game = await PaginatedList<Game>.CreateAsync(gameResult, page, pageSize);
            return game;
        }

        // ketu do te implementojme te gjithe logjiken e kodit qe do te jete e nevojshme qe te implementohet vetem per Game Entity
        // prandaj tani per tani eshte bosh


        public async Task<Game> GameCategoryDetailsByIdAsync(int id)
        {
            return await _context.Games.Include(c => c.CategoryGames).ThenInclude(cg => cg.Category).FirstOrDefaultAsync(c => c.Id == id); 
        }
       
    }
}
