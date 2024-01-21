using DMAWS1.models;

namespace DMAWS1.Repository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product product, IFormFile file);
        //Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);

        //update status product
        Task<Product> UpdateStatusProduct(int id);

        //hiển thị danh sách có status là true
        Task<IEnumerable<Product>> GetProductsStatusTrue();
    }
}
