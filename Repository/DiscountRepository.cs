using GameLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Repository
{
    public class DiscountRepository : BaseRepository<Discount>
    {
        private readonly ApplicationDbContext _context;
        public DiscountRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<List<Discount>> GetAllDiscountsGameIncludedAsync()
        {
            return await _context.Discounts.Include(x => x.Game).ToListAsync();
        }
    }
}
