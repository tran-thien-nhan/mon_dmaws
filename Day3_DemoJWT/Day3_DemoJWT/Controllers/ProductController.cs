using Day3_DemoJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day3_DemoJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext db;

        public ProductController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetProduct()
        {
            return Ok(await db.Products.ToListAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostProduct(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var pro = await db.Products.SingleOrDefaultAsync(p => p.Id == id);
            db.Products.Remove(pro);
            db.SaveChangesAsync();
            return Ok();
        }
    }
}
