using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
