using Api.Constants;
using Api.Extensions;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
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

        protected int GetUserId()
        {
            if(Request.Headers.ContainsKey(HeaderConstants.Authorization))
            {
                var userId = Request.Headers.GetUserId();

                if(userId.HasValue)
                {
                    return userId.Value;
                }
            }

            throw new UnauthorizedException("User not logged in!");
        }
    }
}
