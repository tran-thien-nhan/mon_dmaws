using Microsoft.EntityFrameworkCore;

namespace Pretest_3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { Username = "nhan", Password = "123", Balance = 1000},
                new Account { Username = "thien", Password = "123", Balance = 900 },
                new Account { Username = "tran", Password = "123", Balance = 1500 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
