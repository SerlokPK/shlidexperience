using Common;
using Common.Helpers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;

namespace Api.Controllers
{
    [Route("api/presentations")]
    [Authorize]
    public class PresentationController : BaseController
    {
        private readonly IPresentationService _presentationService;

        public PresentationController(IOptions<AppSettings> options, IPresentationService presentationService) : base(options)
        {
            DependencyHelper.ThrowIfNull(presentationService);

            _presentationService = presentationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = GetUserId();


            return Ok();
        }
    }
}
