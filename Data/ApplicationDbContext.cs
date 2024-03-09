using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
<<<<<<< HEAD
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Notification> Notifications { get; set; }
=======
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Game> Games { get; set;}
        public DbSet<Category> Categories { get; set;}
>>>>>>> bbf436b5263b3a80a4fe172ce114f1027fd665cd
    }
}