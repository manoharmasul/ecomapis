using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepositoryAsync cartRepo;
        public CartController(ICartRepositoryAsync cartRepo)
        {
            this.cartRepo = cartRepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(CartModel cart)
        {
            var result=await cartRepo.AddToCart(cart);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(int Id)
        {
            var result=await cartRepo.RemoveCart(Id);
            return Ok(result);
        }
        [HttpGet("GetAllCart")]
        public async Task<IActionResult> GetAllCart(int UserId)
        {
            var result=await cartRepo.GetAllCart(UserId);
            return Ok(result);
        }
    }
}
