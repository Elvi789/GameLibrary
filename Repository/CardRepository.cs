using GameLibrary.Data;

namespace GameLibrary.Repository
{
    public class CardRepository : BaseRepository<Card>
    {
        private readonly ApplicationDbContext _context;
        public CardRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
