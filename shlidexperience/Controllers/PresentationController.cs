using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;

namespace Api.Controllers
{
    [Route("api/presentations")]
    [ApiController]
    public class PresentationController : BaseController
    {
        public PresentationController(IOptions<AppSettings> options) : base(options)
        {
        }
    }
}
