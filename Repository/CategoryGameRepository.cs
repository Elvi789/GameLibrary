using GameLibrary.Data;

namespace GameLibrary.Repository
{
    public class CategoryGameRepository : BaseRepository<CategoryGame>
    {
        private readonly ApplicationDbContext _context;
        public CategoryGameRepository(ApplicationDbContext context) : base(context) { }


        // per momentin nuk kemi ndodnje metode specifike pervec krudeve te cilen do te na duhet e ta shkruajme specifikisht ne repository.

    }
}
