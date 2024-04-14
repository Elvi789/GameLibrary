using GameLibrary.Data;
using GameLibrary.Repository.Pagination;
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
        public async Task<PaginatedList<Discount>> GetPaginatedDiscount(int page = 1, int pageSize = 10)
        {
            var disResult = _context.Discounts.OrderByDescending(x => x.Id).AsQueryable();
            var discount = await PaginatedList<Discount>.CreateAsync(disResult, page, pageSize);
            return discount;
        }
    }
}
