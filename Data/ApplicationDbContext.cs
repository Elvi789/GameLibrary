using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Game> Games { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<CategoryGame> CategoryGames { get; set;}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<CategoryGame>()
            //    .HasKey(x => new {x.CategoryId, x.GameId});

            //builder.Entity<CategoryGame>()
            //    .HasOne(m => m.Game)
            //    .WithMany(am => am.CategoryGames)
            //    .HasForeignKey(x => x.GameId)
            //    .OnDelete(DeleteBehavior.SetNull); // edhe nqs e kemi t elidhur me nje category, game mund te fshihet dhe mund te behet setnull.

            //builder.Entity<CategoryGame>()
            //    .HasOne(x => x.Category)
            //    .WithMany(x => x.CategoryGames)
            //    .HasForeignKey(x => x.CategoryId)
            //    .OnDelete(DeleteBehavior.Restrict); // i bejme restrict pasi nqs kemi nje loje nuk duhet te na fshihet category.


            base.OnModelCreating(builder);
        }
    }
}