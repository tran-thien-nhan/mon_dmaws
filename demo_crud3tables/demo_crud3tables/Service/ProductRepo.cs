using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Data;
using demo_crud3tables.Helper;
using demo_crud3tables.Models;
using demo_crud3tables.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json;

namespace demo_crud3tables.Service
{
    public class ProductRepo : IProductRepo
    {
        private readonly DatabaseContext db;

        public ProductRepo(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<CustomResult> Delete(string id)
        {
            try
            {
                var product = await db.Products.SingleOrDefaultAsync(p => p.ProductID == id);
                if (product == null)
                {
                    return new CustomResult(404, "Product not found", null);
                }
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return new CustomResult(200, "Success", null);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> GetAll()
        {
            try
            {
                var products = await db.Products.ToListAsync();

                return new CustomResult(200, "Success", products);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }


        public async Task<CustomResult> GetByID(string id)
        {
            try
            {
                var product = await db.Products.SingleOrDefaultAsync(p => p.ProductID == id);
                if (product == null)
                {
                    return new CustomResult(404, "Product not found", null);
                }
                return new CustomResult(200, "Success", product);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> Insert(Product product, IFormFile file)
        {
            try
            {
                product.ProductID = Guid.NewGuid().ToString();
                // Lưu hình ảnh và cập nhật đường dẫn trong sản phẩm
                if (file != null)
                {
                    product.ImagePath = FileUpload.SaveImages("productImage", file);
                }

                // Tạo ProductID mới nếu chưa được cung cấp
                if (string.IsNullOrEmpty(product.ProductID))
                {
                    product.ProductID = Guid.NewGuid().ToString();
                }

                // Thiết lập thời gian tạo và cập nhật
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;

                // Kiểm tra sự tồn tại của danh mục và nhà cung cấp
                var category = await db.Categories.SingleOrDefaultAsync(c => c.CategoryID == product.CategoryID);
                if (category == null)
                {
                    return new CustomResult(404, "Category not found", null);
                }

                var supplier = await db.Suppliers.SingleOrDefaultAsync(s => s.SupplierID == product.SupplierID);
                if (supplier == null)
                {
                    return new CustomResult(404, "Supplier not found", null);
                }

                // Gán danh mục và nhà cung cấp cho sản phẩm
                product.Category = category;
                product.Supplier = supplier;

                // Thêm sản phẩm vào database
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();

                return new CustomResult(200, "Product created successfully", product);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                if (innerException is SqlException sqlException)
                {
                    if (sqlException.Number == 2627)
                    {
                        return new CustomResult(409, "Duplicate key violation", null);
                    }
                }
                return new CustomResult(500, ex.Message, null);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> Update(Product product, IFormFile file)
        {
            try
            {
                var productInDb = await db.Products.SingleOrDefaultAsync(p => p.ProductID == product.ProductID);
                if (productInDb == null)
                {
                    return new CustomResult(404, "Product not found", null);
                }
                productInDb.ProductName = product.ProductName;
                productInDb.SupplierID = product.SupplierID;
                productInDb.CategoryID = product.CategoryID;
                productInDb.Quantity = product.Quantity;
                productInDb.Price = product.Price;
                if (file != null)
                {
                    if (productInDb.ImagePath != null)
                    {
                        FileUpload.DeleteImage(productInDb.ImagePath);
                    }
                    productInDb.ImagePath = FileUpload.SaveImages("productImage", file);
                }
                await db.SaveChangesAsync();
                return new CustomResult(200, "Success", productInDb);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }
    }
}
