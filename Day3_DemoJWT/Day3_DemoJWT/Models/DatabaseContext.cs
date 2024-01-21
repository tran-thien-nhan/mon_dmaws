using Microsoft.EntityFrameworkCore;

namespace Day3_DemoJWT.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Pepsi", Price = 12, Description = "Nuoc ngot" },
                new Product { Id = 2, Name = "Chocopie", Price = 20, Description = "Banh" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Van A", Email = "user@gmail.com", Password = "123", Role = "User" },
                new User { Id = 2, Name = "Van B", Email = "admin@gmail.com", Password = "123", Role = "Admin" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
