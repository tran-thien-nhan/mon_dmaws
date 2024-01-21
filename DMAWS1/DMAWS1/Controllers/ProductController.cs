using DMAWS1.Helper;using DMAWS1.models;
using DMAWS1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMAWS1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo repo;

        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await repo.GetProducts();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromForm] Product product, IFormFile file)
        {
            return await repo.AddProduct(product, file);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await repo.DeleteProduct(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateStatusProduct(int id)
        {
            var product = await repo.UpdateStatusProduct(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpGet("status")]
        public async Task<IEnumerable<Product>> GetProductsStatusTrue()
        {
            return await repo.GetProductsStatusTrue();
        }
    }
}
