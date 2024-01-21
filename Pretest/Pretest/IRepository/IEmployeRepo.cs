using Pretest.Models;

namespace Pretest.IRepository
{
    public interface IEmployeRepo
    {
        Task<bool> checkLogin(string id, string password);
        Task<IEnumerable<tblEmp>> FindAll(float minSalary, float maxSalary);
        Task<tblEmp> UpdateSalary(string id, float salary);

        Task<IEnumerable<tblEmp>> FindAllEmp();

        Task<tblEmp> AddnewEmp(tblEmp employee);

        Task<tblEmp> DeleteEmp(string id);

        Task<tblEmp> GetOneEmp(string id);
    }
}
