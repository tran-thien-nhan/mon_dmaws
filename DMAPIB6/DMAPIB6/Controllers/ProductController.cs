using DMAPIB6.Helper;
using DMAPIB6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMAPIB6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public ProductController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse<IEnumerable<Product>>>> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            if (products == null)
            {
                return NotFound(new APIResponse<IEnumerable<Product>>(products, "get all fail", 204));
            }
            var response = new APIResponse<IEnumerable<Product>>(products, "get all successfully", 200);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse<Product>>> PostProduct([FromForm] Product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return APIResponse<Product>.BadRequest(ModelState);
            }
            try
            {
                product.ImagePath = FileUpload.SaveImages("productImage", file);
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return Created("Success", new APIResponse<Product>(product, "Created product successfully", 201));
            }
            catch (Exception ex)
            {
                return APIResponse<Product>.Exception(ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse<Product>>> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new APIResponse<Product>(null, "Not found product", 404));
            }
            if (product.ImagePath != null)
            {
                FileUpload.DeleteImage(product.ImagePath);
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok(new APIResponse<Product>(product, "deleted product successfully", 200));
        }

        [HttpPut]
        public async Task<ActionResult<APIResponse<Product>>> UpdateProduct([FromForm] Product product, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return APIResponse<Product>.BadRequest(ModelState);
            }
            var productUpdate = await _dbContext.Products.FindAsync(product.Id);
            if (productUpdate != null)
            {
                try
                {
                    if (file != null)
                    {
                        if (productUpdate.ImagePath != null)
                        {
                            FileUpload.DeleteImage(productUpdate.ImagePath);
                        }
                        product.ImagePath = FileUpload.SaveImages("ProductImage", file);
                    }
                    productUpdate.Name = product.Name;
                    productUpdate.Price = product.Price;
                    productUpdate.ImagePath = product.ImagePath;

                    _dbContext.Products.Update(productUpdate);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new APIResponse<Product>
                        (product, "Update product successfully", 200));
                }
                catch (Exception ex)
                {
                    return APIResponse<Product>.Exception(ex);
                }
            }
            return NotFound(new APIResponse<Product>(null, "Not found product", 404));
        }
    }
}
