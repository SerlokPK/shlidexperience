using Api.Extensions;
using Common;
using Common.Helpers;
using DtoModels.Presentations.Request;
using DtoModels.Slides.Filters;
using DtoModels.Slides.Request;
using Interfaces.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;
using System;

namespace Api.Controllers
{
    [Route("api/presentations")]
    [Authorize]
    public class PresentationController : BaseController
    {
        private readonly IPresentationService _presentationService;
        private readonly ISlideService _slideService;

        public PresentationController(IOptions<AppSettings> options, IPresentationService presentationService,
                                        ISlideService slideService) : base(options)
        {
            DependencyHelper.ThrowIfNull(presentationService, slideService);

            _presentationService = presentationService;
            _slideService = slideService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = GetUserId();
            var presentations = _presentationService.GetPresentations(userId);

            return Ok(presentations);
        }

        [HttpGet("{presentationId}")]
        public IActionResult Get([FromRoute] short presentationId)
        {
            var userId = GetUserId();
            var presentation = _presentationService.GetPresentation(userId, presentationId);

            return Ok(presentation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePresentationModel model)
        {
            var userId = GetUserId();
            var presentationId = _presentationService.CreatePresentation(userId, model);

            return Created(new Uri(Request.GetDisplayUrl()), presentationId);
        }

        [HttpPut]
        public IActionResult Put([FromBody] EditPresentationModel model)
        {
            var userId = GetUserId();
            _presentationService.UpdatePresentation(userId, model);

            return NoContent();
        }

        [HttpPost("{presentationId}/slides")]
        public IActionResult CreateSlide([FromRoute] int presentationId)
        {
            var slideId = _slideService.CreateSlide(presentationId);

            return Ok(slideId);
        }

        [HttpGet("{presentationId}/slides")]
        public IActionResult GetSlides([FromRoute] short presentationId, [FromQuery] SlideFilter filter)
        {
            var getSlidesModel = _slideService.GetSlides(presentationId, filter);
            Response.Headers.AddTotalCount(getSlidesModel.Count);

            return Ok(getSlidesModel.Slides);
        }

        [HttpGet("{presentationId}/slides/{slideId}")]
        public IActionResult GetSlide([FromRoute] short slideId, [FromRoute] int presentationId)
        {
            var slide = _slideService.GetSlide(slideId, presentationId);

            return Ok(slide);
        }

        [HttpPut("{presentationId}/slides/{slideId}")]
        public IActionResult EditSlide([FromRoute] short slideId, [FromRoute] int presentationId, [FromBody] EditSlideModel model)
        {
            var slide = _slideService.EditSlide(model);

            return Ok(slide);
        }

        [HttpDelete("{presentationId}/slides/{slideId}")]
        public IActionResult RemoveSlide([FromRoute] short slideId, [FromRoute] int presentationId)
        {
            _slideService.DeleteSlide(slideId, presentationId);

            return NoContent();
        }
    }
}
