using Common;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace shlidexperience.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        internal readonly AppSettings _appSettings;

        public BaseController(IOptions<AppSettings> options)
        {
            DependencyHelper.ThrowIfNull(options);

            _appSettings = options.Value;
        }
    }
}
