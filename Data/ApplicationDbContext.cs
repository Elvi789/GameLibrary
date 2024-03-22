using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Game> Games { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        public DbSet<Category> Categories { get; set;}

        public DbSet<CategoryGame> CategoryGames { get; set;}
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            
            base.OnModelCreating(builder);
        }

    }
}

