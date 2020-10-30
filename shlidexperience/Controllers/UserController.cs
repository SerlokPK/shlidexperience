using Common;
using Common.Helpers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace shlidexperience.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IOptions<AppSettings> options, IUserService userService) : base(options)
        {
            DependencyHelper.ThrowIfNull(userService);

            _userService = userService;
        }

        [HttpGet("{userId}")]
        public IActionResult Get([FromRoute] int userId)
        {
            var user = _userService.GetUserById(userId);

            return Ok(user);
        }
    }
}
