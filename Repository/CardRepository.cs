using GameLibrary.Data;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Repository
{
    public class CardRepository : BaseRepository<Card>
    {
        private readonly ApplicationDbContext _context;
        public CardRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Card>> GetPaginatedCard(int page = 1, int pageSize = 10)
        {
            var cardResult = _context.Cards.OrderByDescending(x => x.Id).AsQueryable();
            var card = await PaginatedList<Card>.CreateAsync(cardResult, page, pageSize);
            return card;
        }
    }
}
