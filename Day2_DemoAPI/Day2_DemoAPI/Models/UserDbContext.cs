using Microsoft.EntityFrameworkCore;

namespace Day2_DemoAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Username = "user1", Password = "123", Name = "Van A", YoB = 2000 },
                new User { Username = "user2", Password = "123", Name = "Thi B", YoB = 2001 },
                new User { Username = "user3", Password = "123", Name = "Thi C", YoB = 2002 }
            );
        }
    }
}
