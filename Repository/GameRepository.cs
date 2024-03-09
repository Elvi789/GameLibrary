using GameLibrary.Data;
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


        // ketu do te implementojme te gjithe logjiken e kodit qe do te jete e nevojshme qe te implementohet vetem per Game Entity
        // prandaj tani per tani eshte bosh
       
    }
}
