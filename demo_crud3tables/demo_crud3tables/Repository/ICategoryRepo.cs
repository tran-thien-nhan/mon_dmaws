using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Models;

namespace demo_crud3tables.Repository
{
    public interface ICategoryRepo
    {
        Task<CustomResult> GetAll();
        Task<CustomResult> GetByID(string id);
        Task<CustomResult> Insert(Category category);
        Task<CustomResult> Update(Category category);
        Task<CustomResult> Delete(string id);
    }
}
