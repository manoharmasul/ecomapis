using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepositoryAsync shopRepository;
        public ShopController(IShopRepositoryAsync shopRepository)
        {
            this.shopRepository = shopRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddShop(Shop shop)
        {
            var result=await shopRepository.AddShop(shop);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateShop(Shop shop)
        {
            var result=await shopRepository.UpdateShop(shop);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteShop(int Id)
        {
            var result=await shopRepository.DeleteShope(Id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShop(string? SearchText)
        {
            var result=await shopRepository.GetAllShop(SearchText);
            return Ok(result);
        }
        [HttpGet("GetShopById")]
        public async Task<IActionResult> GetShopById(int  Id)
        {
            var result=await shopRepository.GetShopById(Id);
            return Ok(result);
        }
    }
}
