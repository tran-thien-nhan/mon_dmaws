using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Data;
using demo_crud3tables.Models;
using demo_crud3tables.Repository;
using Microsoft.EntityFrameworkCore;

namespace demo_crud3tables.Service
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly DatabaseContext db;

        public SupplierRepo(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<CustomResult> Delete(string id)
        {
            try
            {
                var supplier = db.Suppliers.Find(id);
                if (supplier == null)
                {
                    return new CustomResult(404, "Supplier not found", null);
                }
                db.Suppliers.Remove(supplier);
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
                var suppliers = await db.Suppliers.ToListAsync();
                return new CustomResult(200, "Success", suppliers);
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
                var supplier = db.Suppliers.Find(id);
                if (supplier == null)
                {
                    return new CustomResult(404, "Supplier not found", null);
                }
                return new CustomResult(200, "Success", supplier);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> Insert(Supplier supplier)
        {
            try
            {
                db.Suppliers.Add(supplier);
                await db.SaveChangesAsync();
                return new CustomResult(200, "Success", null);
            }
            catch (Exception ex)
            {
                return new CustomResult(500, ex.Message, null);
            }
        }

        public async Task<CustomResult> Update(Supplier supplier)
        {
            try
            {
                var oldSupplier = db.Suppliers.SingleOrDefaultAsync(s => s.SupplierID == supplier.SupplierID);
                if (oldSupplier == null)
                {
                    return new CustomResult(404, "Supplier not found", null);
                }
                oldSupplier.Result.SupplierName = supplier.SupplierName;
                oldSupplier.Result.City = supplier.City;
                db.Suppliers.Update(oldSupplier.Result);
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
