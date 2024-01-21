using Day1.Data;
using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepo repo;

        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await repo.GetProducts());
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            return Ok(await repo.PostProduct(product));
        }
    }
}
