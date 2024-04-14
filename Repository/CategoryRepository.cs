using GameLibrary.Data;
using GameLibrary.Repository.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameLibrary.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {

        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) { _context = context; }

        public async Task<PaginatedList<Category>> GetPaginatedCategory(int page = 1, int pageSize = 10)
        {
            var catResult = _context.Categories.OrderByDescending(x => x.Id).AsQueryable();
            var cat = await PaginatedList<Category>.CreateAsync(catResult, page, pageSize);
            return cat;
        }



        // Nese do te na duhet ndonje metode e gatshme dhe specifike rreth category do ta shtojme ne kete file, ne te kundert te gjitha 
        // metodat baze jane te implementuara ne BaseRepository 
        // dhe ne servisin perkates


        public async Task<Category> GameCategoryDetailsByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.CategoryGames).ThenInclude(cg => cg.Game).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
