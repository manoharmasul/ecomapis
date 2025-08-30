using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonDropdownController : ControllerBase
    {
        private readonly ICommondropdownasync commondropdown;
        public CommonDropdownController(ICommondropdownasync commondropdown)
        {
            this.commondropdown = commondropdown;
        }
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetAllEmployeeRole()
        {
            var result=await commondropdown.GetEmployeeRole();
            return Ok(result);
        }
        [HttpGet("GetState")]
        public async Task<IActionResult> GetState()
        {
            var result = await commondropdown.GetState();
            return Ok(result);
        }
        [HttpGet("GetDistrict")]
        public async Task<IActionResult> GetDistrict(int StateId)
        {
            var result = await commondropdown.GetDistrict(StateId);
            return Ok(result);
        }
        [HttpGet("GetTaluka")]
        public async Task<IActionResult> GetTaluka(int DistId)
        {
            var result = await commondropdown.GetTaluka(DistId);
            return Ok(result);
        }
        [HttpGet("GetCity")]
        public async Task<IActionResult> GetCity(int TalukaId)
        {
            var result = await commondropdown.GetCity(TalukaId);
            return Ok(result);
        }
        [HttpGet("GetCatergories")]
        public async Task<IActionResult> GetCatergories()
        {
            var result = await commondropdown.GetCategory();
            return Ok(result);
        }
        [HttpGet("GetShopDrop")]
        public async Task<IActionResult> GetShopDrop()
        {
            var result=await commondropdown.GetShopDrop();
            return Ok(result);
        }
        [HttpGet("GetDeliveryBoyes")]
        public async Task<IActionResult> GetDeliveryBoyes(int UserId)
        {
            var result = await commondropdown.GetDeliveryBoyes(UserId);
            return Ok(result);
        }
        [HttpGet("GetOrderstutsDrop")]
        public async Task<IActionResult> GetOrderstutsDrop()
        {
            var result = await commondropdown.GetOrderstutsDrop();
            return Ok(result);
        }
    }
}
