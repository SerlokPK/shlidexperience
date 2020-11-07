using Common;
using Common.Helpers;
using DtoModels.User.Request;
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

        [HttpPut("{userId}/email")]
        public IActionResult ChangeEmail([FromBody] ChangeEmailModel model)
        {
            var user = _userService.ChangeEmail(model);

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public IActionResult EditUser([FromBody] EditUserModel model)
        {
            var user = _userService.EditUser(model);

            return Ok(user);
        }

        [HttpPut("{userId}/password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            _userService.ChangePassword(model);

            return NoContent();
        }
    }
}
