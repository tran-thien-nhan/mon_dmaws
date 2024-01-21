using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Models;
using demo_crud3tables.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_crud3tables.Controllers
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
        public async Task<CustomResult> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<CustomResult> GetByID(string id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task<CustomResult> Create([FromForm] Product product, IFormFile file)
        {
            return await repo.Insert(product, file);
        }

        [HttpPut]
        public async Task<CustomResult> Update([FromForm] Product product, IFormFile file)
        {
            return await repo.Update(product, file);
        }

        [HttpDelete("{id}")]
        public async Task<CustomResult> Delete(string id)
        {
            return await repo.Delete(id);
        }
    }
}
