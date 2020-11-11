using Common;
using Common.Helpers;
using DtoModels.Slides.Request;
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
            DependencyHelper.ThrowIfNull(slideService);

            _slideService = slideService;
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var types = _slideService.GetTypes();

            return Ok(types);
        }

        [HttpGet("{slideId}")]
        public IActionResult Get([FromRoute] short slideId)
        {
            var slide = _slideService.GetSlide(slideId);

            return Ok(slide);
        }

        [HttpPut("{slideId}")]
        public IActionResult Put([FromRoute] short slideId, [FromBody] EditSlideModel model)
        {
            var slide = _slideService.GetSlide(slideId);

            return Ok(slide);
        }
    }
}
