using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using shlidexperience.Controllers;

namespace Api.Controllers
{
    [Route("api/options")]
    [Authorize]
    public class OptionController : BaseController
    {
        public OptionController(IOptions<AppSettings> options) : base(options)
        {
            
        }
    }
}
