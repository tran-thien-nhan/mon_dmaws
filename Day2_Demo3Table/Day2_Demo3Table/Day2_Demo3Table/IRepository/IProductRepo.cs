using Day2_Demo3Table.Models;

namespace Day2_Demo3Table.IRepository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
