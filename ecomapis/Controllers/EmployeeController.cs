using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAsyncRepository employee;
        public EmployeeController(IEmployeeAsyncRepository employee)
        {
            this.employee = employee;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(EmployeeModel model)
        {
            var result=await employee.AddEmployee(model);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel model)
        {
            var result=await employee.UpdateEmployee(model);
            return Ok(result);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result=await employee.GetEmployeeById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(string? SearchText)
        {
            var result = await employee.GetAllEmployee(SearchText);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var result = await employee.DeleteEmployee(Id);
            return Ok(result);
        }
    }
}
