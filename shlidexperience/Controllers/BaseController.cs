﻿using Common;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;

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
            return int.Parse(User.Claims.First(x => x.Type == ClaimTypes.Sid).Value);
        }
    }
}
