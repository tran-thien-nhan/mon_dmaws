using Day2_Demo3Table.Models;

namespace Day2_Demo3Table.IRepository
{
    public interface ICartRepo
    {
        Task<int> AddCart(Cart cart);

        Task<int> DeleteCart(int id);

        Task<int> UpdateQuantity(int id, int quantity);

        Task<IEnumerable<Cart>> GetAll(int userId);
    }
}
