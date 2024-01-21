using DMAWS1.Data;
using DMAWS1.Helper;
using DMAWS1.models;
using DMAWS1.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DMAWS1.Services
{
    public class ProductRepo : IProductRepo
    {
        private readonly DatabaseContext db;

        public ProductRepo(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Product> AddProduct(Product product, IFormFile file)
        {
            product.Image = FileUpload.SaveImages("productImage", file);
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null) return null;
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsStatusTrue()
        {
            return await db.Products.Where(p => p.Status == true).ToListAsync();
        }

        public async Task<Product> UpdateStatusProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null) return null;
            product.Status = !product.Status;
            await db.SaveChangesAsync();
            return product;
        }
    }
}
