using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderrepo;
        public OrderController(IOrderRepository orderrepo)
        {
            this.orderrepo = orderrepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(OrderModel order)
        {
            var result=await orderrepo.AddProduct(order);
            return Ok(result);
        }
        [HttpGet("GetAllOrdersByUserId")]
        public async Task<IActionResult> GetAllOrdersByUserId(int userId)
        {
            var result = await orderrepo.GetAllOrdersByUserId(userId);
            return Ok(result);
        }
        [HttpGet("GetAllOrdersShops")]
        public async Task<IActionResult> GetAllOrdersShops(int UserId)
        {
            var result = await orderrepo.GetAllOrdersShops(UserId);
            return Ok(result);
        }
        [HttpPost("AssingOrder")]
        public async Task<IActionResult> AssingOrder(AssingOrderModel order)
        {
            var result=await orderrepo.AssingOrder(order);
            return Ok(result);
        }
        [HttpPut("UpdateAssingOrder")]
        public async Task<IActionResult> UpdateAssingOrder(AssingOrderModel ordmodel)
        {
            var result=await orderrepo.UpdateAssingOrder(ordmodel);
            return Ok(result);
        }
        [HttpGet("GetOrderUpdates")]
        public async Task<IActionResult> GetOrderUpdates(int UserId)
        {
            var result = await orderrepo.GetOrderUpdates(UserId);
            return Ok(result);
        }
        [HttpPut("UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderModel updateOrder)
        {
            var result = await orderrepo.UpdateOrderStatus(updateOrder);
            return Ok(result);
        }
        [HttpPost("SendOrderOtp")]
        public async Task<IActionResult> SendOrderOtp(sendOrderotpModal OrdId)
        {
            var result = await orderrepo.SendOrderOtp(OrdId);
            return Ok(result);
        }
    }
}
