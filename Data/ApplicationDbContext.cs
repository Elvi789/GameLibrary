using Microsoft.AspNetCore.Identity;
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

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Card> Cards { get; set; }

        const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                SecurityStamp = string.Empty,
            });
        }
    }
}


// Test for sync