using DMAWS1.models;
using Microsoft.EntityFrameworkCore;

namespace DMAWS1.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
