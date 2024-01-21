using Day2_Demo3Table.Data;
using Day2_Demo3Table.IRepository;
using Day2_Demo3Table.Models;
using Day2_Demo3Table.ModelStatic;
using Microsoft.EntityFrameworkCore;

namespace Day2_Demo3Table.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext db;

        public UserRepo(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await db.Users.SingleOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await db.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
            UserStatic.userId = user.Id;
            return user;
        }
    }
}
