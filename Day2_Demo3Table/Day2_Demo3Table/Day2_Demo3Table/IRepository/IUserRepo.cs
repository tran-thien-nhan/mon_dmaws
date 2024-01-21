using Day2_Demo3Table.Models;

namespace Day2_Demo3Table.IRepository
{
    public interface IUserRepo
    {
        Task<User> Login(string email, string password);

        Task<User> GetUser(int userId);
    }
}
