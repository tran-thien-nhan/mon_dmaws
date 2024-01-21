using Day2_Demo3Table.IRepository;
using Day2_Demo3Table.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2_Demo3Table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;
        private readonly ICartRepo cartRepo;

        public ProductController(IProductRepo productRepo, ICartRepo cartRepo)
        {
            this.productRepo = productRepo;
            this.cartRepo = cartRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await productRepo.GetProducts());
        }

        [HttpPost]
        public async Task<ActionResult> AddCart(Cart cart)
        {
            try
            {
                await cartRepo.AddCart(cart);
                return Ok();
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("showCart/{userId}")]
        public async Task<ActionResult> ShowCart(int userId)
        {
            return Ok(await cartRepo.GetAll(userId));
        }

        [HttpDelete("deleteCart/{cartId}")]
        public async Task<ActionResult> DeleteCart(int cartId)
        {
            var result = await cartRepo.DeleteCart(cartId);
            if(result == 1)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
