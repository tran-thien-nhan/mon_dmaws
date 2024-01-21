using Demo_CustomStatusCode.CustomStatusCode;
using Demo_CustomStatusCode.Models;
using Demo_CustomStatusCode.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_CustomStatusCode.Controllers
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
        public async Task<Product> GetProducts()
        {
            try
            {
                var result = await repo.GetAll();
                if (result == null)
                {
                    CustomResult custom = new CustomResult(401, "something error", null);
                    return null;
                }
                else if (result.Count() == 0)
                {
                    CustomResult custom = new CustomResult(201, "list empty", result);
                    return null;
                }
                else
                {
                    CustomResult custom = new CustomResult(200, "get list success", result);
                    return null;
                }
            }
            catch (Exception ex)
            {
                CustomResult custom = new CustomResult(402, ex.Message, null);
                return null;
            }
        }
    }
}
