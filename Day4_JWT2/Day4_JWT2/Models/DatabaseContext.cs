using Microsoft.EntityFrameworkCore;

namespace Day4_JWT2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Email = "user@gmail.com", Name = "Van A", Password = "123", Role = "User" },
                new Account { Id = 2, Email = "admin@gmail.com", Name = "Van B", Password = "123", Role = "Admin" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chocopie", Price = 20, Description = "banh" },
                new Product { Id = 2, Name = "Pepsi", Price = 10, Description = "nuoc" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
