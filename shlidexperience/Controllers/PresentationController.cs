using Common;
using Common.Helpers;
using DtoModels.Presentations.Request;
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

        public PresentationController(IOptions<AppSettings> options, IPresentationService presentationService) : base(options)
        {
            DependencyHelper.ThrowIfNull(presentationService);

            _presentationService = presentationService;
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
        public IActionResult Put([FromBody] CreatePresentationModel model)
        {
            var userId = GetUserId();
            var presentationId = _presentationService.CreatePresentation(userId, model);

            return Created(new Uri(Request.GetDisplayUrl()), presentationId);
        }
    }
}
