using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Models;

namespace demo_crud3tables.Repository
{
    public interface ISupplierRepo
    {
        Task<CustomResult> GetAll();
        Task<CustomResult> GetByID(string id);
        Task<CustomResult> Insert(Supplier supplier);
        Task<CustomResult> Update(Supplier supplier);
        Task<CustomResult> Delete(string id);
    }
}
