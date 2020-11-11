using Common;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;

namespace Api.Controllers
{
    [Route("api/slides")]
    [Authorize]
    public class SlideController : BaseController
    {
        private readonly ISlideService _slideService;

        public SlideController(IOptions<AppSettings> options, ISlideService slideService) : base(options)
        {
            _slideService = slideService;
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var types = _slideService.GetTypes();

            return Ok(types);
        }
    }
}
