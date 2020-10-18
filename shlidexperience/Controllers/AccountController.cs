using Common;
using DomainModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Helpers;

namespace shlidexperience.Controllers
{
    [Route("api/account")]
    public class AccountController : BaseController
    {
        public AccountController(IOptions<AppSettings> options) : base(options)
        {
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var token = JwtTokenHelper.GenerateJSONWebToken(new User { Email = "test", UserId = 1 }, _appSettings.JwtKey);
            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Moze");
        }
    }
}
