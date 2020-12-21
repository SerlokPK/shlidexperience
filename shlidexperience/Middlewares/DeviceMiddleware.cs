using Api.Extensions;
using Common.Helpers;
using DomainModels.Exceptions;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class DeviceMiddleware
    {
        private readonly RequestDelegate _next;

        public DeviceMiddleware(RequestDelegate next)
        {
            DependencyHelper.ThrowIfNull(next);

            _next = next;
        }

        public async Task Invoke(HttpContext context, IAccountService accountService)
        {
            var deviceId = context.Request.Headers["DeviceId"].FirstOrDefault();

            if (deviceId != null)
            {
                var userId = context.Request.Headers.GetUserId();
                accountService.SaveDevice(deviceId, userId);
            }

            await _next(context);
        }
    }
}
