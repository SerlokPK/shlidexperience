using Api.Extensions;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

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
            var userId = Request.Headers.GetUserId();

            if (userId.HasValue)
            {
                return userId.Value;
            }

            throw new UnauthorizedException("User not logged in!");
        }

        protected Guid GetDeviceId()
        {
            var deviceId = Request.Headers.GetDeviceId();

            if (deviceId.HasValue)
            {
                return deviceId.Value;
            }

            throw new UnauthorizedException("There was an error, please reload page!");
        }
    }
}
