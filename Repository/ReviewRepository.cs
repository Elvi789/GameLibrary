using GameLibrary.Data;
using GameLibrary.Migrations;
using GameLibrary.Repository.Pagination;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Repository
{
    public class ReviewRepository : BaseRepository<Review>
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetAllReviewsGameIncludedAsync()
        {
            return await _context.Reviews.Include(x => x.Game).ToListAsync();
        }
        public async Task<PaginatedList<Review>> GetPaginatedReview(int page = 1, int pageSize = 10)
        {
            var reviewResult = _context.Reviews.OrderByDescending(x => x.Id).AsQueryable();
            var review = await PaginatedList<Review>.CreateAsync(reviewResult, page, pageSize);
            return review;
        }
    }
}
