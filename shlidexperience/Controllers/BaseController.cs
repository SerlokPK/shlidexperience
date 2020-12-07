using Common;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace shlidexperience.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private const string _authorization = "Authorization";

        internal readonly AppSettings _appSettings;

        public BaseController(IOptions<AppSettings> options)
        {
            DependencyHelper.ThrowIfNull(options);

            _appSettings = options.Value;
        }

        protected int GetUserId()
        {
            if(Request.Headers.ContainsKey(_authorization))
            {
                var token = Request.Headers.First(x => x.Key == _authorization).Value;
                var id = JwtTokenHelper.GetIdClaim(token);

                if (!string.IsNullOrEmpty(id))
                {
                    return int.Parse(id);
                }
            }

            throw new System.Exception("User not logged in!");
        }
    }
}
