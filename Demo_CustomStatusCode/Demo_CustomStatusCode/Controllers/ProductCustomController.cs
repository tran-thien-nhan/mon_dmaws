using Demo_CustomStatusCode.CustomStatusCode;
using Demo_CustomStatusCode.Models;
using Demo_CustomStatusCode.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_CustomStatusCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {
        private readonly IProductCustomRepo repo;

        public ProductCustomController(IProductCustomRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<CustomResult> GetProducts()
        {
           return await repo.GetAll();
        }

        [HttpGet("getone/{id}")]   
        public async Task<CustomResult> GetProductById(int id)
        {
            return await repo.GetById(id);
        }

        [HttpPost]
        public async Task<CustomResult> AddProduct([FromForm] Product product)
        {
            return await repo.AddProduct(product);
        }

        [HttpPut]
        public async Task<CustomResult> UpdateProduct([FromForm] Product product)
        {
            return await repo.UpdateProduct(product);
        }

        [HttpDelete("id")]
        public async Task<CustomResult> DeleteProduct(int id)
        {
            return await repo.DeleteProduct(id);
        }
    }
}
