using Day1.Data;
using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Services
{
    public class ProductService : IProductRepo
    {
        private readonly DatabaseContext db;

        public ProductService(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<Product> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
            return product;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var list = await db.Products.ToListAsync();
            return list;
        }

        public async Task<Product> PostProduct(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> PutProduct(Product product)
        {
            var oldProduct = await GetProductById(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.Price = product.Id;
            await db.SaveChangesAsync();
            return product;
        }
    }
}
