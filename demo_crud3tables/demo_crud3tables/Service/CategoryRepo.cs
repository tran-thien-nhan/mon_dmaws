using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Data;
using demo_crud3tables.Models;
using demo_crud3tables.Repository;
using Microsoft.EntityFrameworkCore;

namespace demo_crud3tables.Service
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly DatabaseContext db;
        public CategoryRepo(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<CustomResult> Delete(string id)
        {
            try
            {
                var category = db.Categories.Find(id);
                if (category == null)
                {
                    return new CustomResult(404, "Category not found", null);
                }
                db.Categories.Remove(category);
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
                var categories = await db.Categories.ToListAsync();
                return new CustomResult(200, "Success", categories);
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
                var category = db.Categories.Find(id);
                if (category == null)
                {
                    return new CustomResult(404, "Category not found", null);
                }
                return new CustomResult(200, "Success", category);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> Insert(Category category)
        {
            try
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return new CustomResult(200, "Success", null);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> Update(Category category)
        {
            try
            {
                var categoryInDB = db.Categories.SingleOrDefaultAsync(c => c.CategoryID == category.CategoryID);
                if (categoryInDB == null)
                {
                    return new CustomResult(404, "Category not found", null);
                }
                categoryInDB.Result.CategoryName = category.CategoryName;
                db.Categories.Update(categoryInDB.Result);
                await db.SaveChangesAsync();
                return new CustomResult(200, "Success", null);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }
    }
}
