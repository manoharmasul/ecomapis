using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userrepo;
        public UserController(IUserRepository userrepo)
        {
            this.userrepo = userrepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser(string? SearchText)
        {
            var result=await userrepo.GetAllUsers(SearchText);

            return Ok(result);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = await userrepo.AddNewUser(user);
            return Ok(result);
        }
        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtp(sendotp otp)
        {
            var result = await userrepo.SendOtp(otp);
            return Ok(result);
        }
        [HttpPost("verifyotp")]
        public async Task<IActionResult> VerifyOtp(sendotp ottp)
        {
            var result = await userrepo.VerifyOtp(ottp);

            return Ok(result);

        }
        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LogInModel login)
        {
            var result = await userrepo.Login(login);

            return Ok(result);

        }
        [HttpPost("setpassowrd")]
        public async Task<IActionResult> SetPassword(SetPassword setpassword)
        {
            var result = await userrepo.SetPassword(setpassword);

            return Ok(result);

        }
        [HttpPut("UpdateNewUser")]
        public async Task<IActionResult> UpdateNewUser(UserModel user)
        {
            var result=await userrepo.UpdateNewUser(user);
            return Ok(result);
        }
        [HttpPost("AddNewUserManually")]
        public async Task<IActionResult> AddNewUserManually(UserModel user)
        {
            var result = await userrepo.AddNewUserManually(user);
            return Ok(result);
        }
    }

}
