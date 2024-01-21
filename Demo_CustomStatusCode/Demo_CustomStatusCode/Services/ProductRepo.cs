using Demo_CustomStatusCode.Data;
using Demo_CustomStatusCode.Models;
using Demo_CustomStatusCode.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo_CustomStatusCode.Services
{
    public class ProductRepo : IProductRepo
    {
        private readonly DatabaseContext db;

        public ProductRepo(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await db.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return product;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                var oldProduct = await GetById(product.Id);
                if (oldProduct == null)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        oldProduct.Price = product.Price;
                        oldProduct.Name = product.Name;
                        oldProduct.Description = product.Description;
                        //db.Products.Update(oldProduct);
                        var result = await db.SaveChangesAsync();
                        if (result == 1)
                        {
                            return oldProduct;                            
                        }
                        return null;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await GetById(id);
            if (product == null)
            {
                return null;
            }
            else
            {
                try
                {
                    db.Products.Remove(product);
                    var result = await db.SaveChangesAsync();
                    if (result == 1)
                    {
                        return product;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
