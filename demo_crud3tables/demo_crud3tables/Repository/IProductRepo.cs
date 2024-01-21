using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Models;

namespace demo_crud3tables.Repository
{
    public interface IProductRepo
    {
        Task<CustomResult> GetAll();
        Task<CustomResult> GetByID(string id);
        Task<CustomResult> Insert(Product product, IFormFile file);
        Task<CustomResult> Update(Product product, IFormFile file);
        Task<CustomResult> Delete(string id);
    }
}
