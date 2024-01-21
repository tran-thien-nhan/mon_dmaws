using Demo_CustomStatusCode.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_CustomStatusCode.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
