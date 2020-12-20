using Api.Extensions;
using Common.Helpers;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class DeviceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAccountService _accountService;

        public DeviceMiddleware(RequestDelegate next, IAccountService accountService)
        {
            DependencyHelper.ThrowIfNull(next, accountService);

            _next = next;
            _accountService = accountService;
        }

        public async Task Invoke(HttpContext context)
        {
            var deviceId = context.Request.Headers["DeviceId"].FirstOrDefault();

            if (deviceId != null)
            {
                var userId = context.Request.Headers.GetUserId();
                _accountService.SaveDevice(deviceId, userId);
            }

            await _next(context);
        }
    }
}
