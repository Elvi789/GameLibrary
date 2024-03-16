using GameLibrary.Data;

namespace GameLibrary.Repository
{
    public class DiscountRepository : BaseRepository<Discount>
    {
        private readonly ApplicationDbContext _context;
        public DiscountRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
