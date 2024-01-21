using demo_crud3tables.CustomStatusCode;
using demo_crud3tables.Models;
using demo_crud3tables.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_crud3tables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepo repo;

        public SupplierController(ISupplierRepo repo)
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
        public async Task<CustomResult> Create(Supplier supplier)
        {
            return await repo.Insert(supplier);
        }

        [HttpPut]
        public async Task<CustomResult> Update(Supplier supplier)
        {
            return await repo.Update(supplier);
        }

        [HttpDelete("{id}")]
        public async Task<CustomResult> Delete(string id)
        {
            return await repo.Delete(id);
        }   
    }
}
