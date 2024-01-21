using Day1.Models;

namespace Day1.Services
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> PostProduct(Product product);
        Task<Product> PutProduct(Product product);
        Task<Product> DeleteProduct(int id);
    }
}
