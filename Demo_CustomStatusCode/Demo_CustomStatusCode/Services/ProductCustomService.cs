using Demo_CustomStatusCode.CustomStatusCode;
using Demo_CustomStatusCode.Data;
using Demo_CustomStatusCode.Models;
using Demo_CustomStatusCode.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Demo_CustomStatusCode.Services
{
    public class ProductCustomService : IProductCustomRepo
    {
        private readonly DatabaseContext db;

        public ProductCustomService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<CustomResult> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return new CustomResult(400, "Invalid input. Product is null.", null);
                }
                product.Id = default; // Set Id to default value for auto-increment
                db.Products.Add(product);
                var result = await db.SaveChangesAsync();

                if (result > 0)
                {
                    return new CustomResult(200, "Created Success", product);
                }
                else
                {
                    return new CustomResult(201, "No changes were made in the database", null);
                }
            }
            catch (DbUpdateException ex)
            {
                // Check for specific DbUpdateException for unique constraint violation (e.g., duplicate key)
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                    return new CustomResult(409, "Duplicate entry. Product with the same key already exists.", null);
                }

                return new CustomResult(500, ex.Message, null);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> DeleteProduct(int id)
        {
            try
            {
                var product = await db.Products.FindAsync(id);
                if (product == null)
                {
                    return new CustomResult(201, "Not Found", null);
                }
                else
                {
                    db.Products.Remove(product);
                    var result = await db.SaveChangesAsync();
                    if (result == 1)
                    {
                        return new CustomResult(200, "Delete Success", product);
                    }
                    return new CustomResult(201, "Delete Error", null);
                }
            }
            catch (Exception ex)
            {
                return new CustomResult(402, ex.Message, null);
            }
        }

        public async Task<CustomResult> GetAll()
        {
            try
            {
                var result = await db.Products.ToListAsync(); // Sử dụng await để đợi kết quả
                if (result == null)
                {
                    return new CustomResult(401, "Something went wrong", null);
                }
                else if (result.Count == 0) // Sửa lại điều kiện kiểm tra độ dài của danh sách
                {
                    return new CustomResult(204, "List is empty", result); // Thay đổi mã trạng thái 201 thành 204 nếu danh sách trống rỗng
                }
                else
                {
                    return new CustomResult(200, "Get list success", result);
                }
            }
            catch (Exception ex)
            {
                return new CustomResult(500, "Internal Server Error: " + ex.Message, null);
            }
        }


        public async Task<CustomResult> GetById(int id)
        {
            try
            {
                var result = await db.Products.FindAsync(id);
                if (result == null)
                {
                    return new CustomResult(404, "Not Found", null); // Thay đổi mã trạng thái 201 thành 404 khi không tìm thấy
                }
                else
                {
                    return new CustomResult(200, "Get success", result);
                }
            }
            catch (Exception ex)
            {
                return new CustomResult(500, "Internal Server Error: " + ex.Message, null);
            }
        }

        public async Task<CustomResult> UpdateProduct(Product product)
        {
            try
            {
                var oldProduct = await db.Products.FindAsync(product.Id);
                if (oldProduct == null)
                {
                    return new CustomResult(404, "Not Found", null); // Thay đổi mã trạng thái 201 thành 404 khi không tìm thấy
                }
                else
                {
                    try
                    {
                        oldProduct.Price = product.Price;
                        oldProduct.Name = product.Name;
                        oldProduct.Description = product.Description;

                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return new CustomResult(200, "Update Success", oldProduct);
                        }
                        return new CustomResult(201, "No changes were made in the database", null);
                    }
                    catch (DbUpdateException ex)
                    {
                        // Check for specific DbUpdateException for unique constraint violation (e.g., duplicate key)
                        if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                        {
                            return new CustomResult(409, "Duplicate entry. Another product with the same key already exists.", null);
                        }

                        return new CustomResult(500, "Internal Server Error: " + ex.Message, null);
                    }
                    catch (Exception ex)
                    {
                        return new CustomResult(500, "Internal Server Error: " + ex.Message, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new CustomResult(500, "Internal Server Error: " + ex.Message, null);
            }
        }

    }
}
