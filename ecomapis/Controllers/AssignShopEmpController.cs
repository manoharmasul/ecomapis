using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignShopEmpController : ControllerBase
    {
        private readonly IAssignEmpShopRepository assingRepo;
        public AssignShopEmpController(IAssignEmpShopRepository assingRepo)
        {
            this.assingRepo = assingRepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddAssingnEmpShop(AssignShopEmpModel model)
        {
            var result = await assingRepo.AssignEmpShopAsync(model);
            return Ok(result);
        }
        [HttpPut("UpdateAssignEmpShop")]
        public async Task<IActionResult> UpdateAssignEmpShop(AssignShopEmpModel model)
        {
            try
            {
                var result = await assingRepo.UpdateEmpShopAsync(model);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("GetAssignShopEmp")]
        public async Task<IActionResult> GetAssignShopEmp()
        {
            var result = await assingRepo.GetAssignEmpShop();
            return Ok(result);
        }
        [HttpGet("GetAssingShopEmpById")]
        public async Task<IActionResult> GetAssingShopEmpById(int Id)
        {
            var result=await assingRepo.GetAssignEmpShopById(Id);
            return Ok(result);
        }
    }
}
