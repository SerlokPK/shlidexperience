using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;

namespace Api.Controllers
{
    [Route("api/slides")]
    [Authorize]
    public class SlideController : BaseController
    {
        public SlideController(IOptions<AppSettings> options) : base(options)
        {

        }
    }
}
