using Day4_JWT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day4_JWT2.Controllers
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
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await db.Products.ToListAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostProduct([FromBody]Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
            var pro = await db.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (pro != null)
            {
                db.Products.Remove(pro);
                await db.SaveChangesAsync();
                return Ok(new { message = "remove product successfully" });
            }
            return Ok(new { message = "no product to be removed" });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")] //kiểm tra đăng nhập
        public async Task<ActionResult> GetProduct(int id)
        {
            var pro = await db.Products.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(pro);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            var existingProduct = await db.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;

            await db.SaveChangesAsync();

            return Ok(existingProduct);
        }

    }
}
