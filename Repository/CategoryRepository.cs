using GameLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameLibrary.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {

        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)  { _context = context; } 

        //public async Task<List<Category>> GetAllCategoriesAsync()
        //{
        //    return await _context.Categories.ToListAsync();
        //}

        //public async Task<Category> GetCategoryByIdAsync(int id)
        //{
        //    return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task CreateCategory(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteCategory(Category category)
        //{
        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task EditCategory(Category category)
        //{
        //    _context.Categories.Update(category);
        //    await _context.SaveChangesAsync();
        //}



        // Nese do te na duhet ndonje metode e gatshme dhe specifike rreth category do ta shtojme ne kete file, ne te kundert te gjitha 
        // metodat baze jane te implementuara ne BaseRepository 
        // dhe ne servisin perkates
    }
}
