using GameLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameLibrary.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {

        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)  { _context = context; } 

       


        // Nese do te na duhet ndonje metode e gatshme dhe specifike rreth category do ta shtojme ne kete file, ne te kundert te gjitha 
        // metodat baze jane te implementuara ne BaseRepository 
        // dhe ne servisin perkates
    }
}
