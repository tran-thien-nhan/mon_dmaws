using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Models;
using demo_crud3tables.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_crud3tables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo repo;

        public CategoryController(ICategoryRepo repo)
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
        public async Task<CustomResult> Create(Category category)
        {
            return await repo.Insert(category);
        }

        [HttpPut]
        public async Task<CustomResult> Update(Category category)
        {
            return await repo.Update(category);
        }

        [HttpDelete("{id}")]
        public async Task<CustomResult> Delete(string id)
        {
            return await repo.Delete(id);
        }
    }
}
