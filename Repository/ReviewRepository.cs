using GameLibrary.Data;
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

    }
}
