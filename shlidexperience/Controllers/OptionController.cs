using Common;
using Common.Helpers;
using DtoModels.Options.Request;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/options")]
    [Authorize]
    public class OptionController : BaseController
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptions<AppSettings> options, IOptionService optionService) : base(options)
        {
            DependencyHelper.ThrowIfNull(optionService);

            _optionService = optionService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveOptionResult(SaveOptionResultModel model)
        {
            model.UserId = GetUserId();
            await _optionService.VoteOnOption(model);

            return Ok();
        }
    }
}
