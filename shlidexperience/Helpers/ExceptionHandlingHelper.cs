using DomainModels.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace shlidexperience.Helpers
{
    public static class ExceptionHandlingHelper
    {
        public static IApplicationBuilder RegisterExceptionHandling(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        if (ex is BaseException be)
                        {
                            context.Response.StatusCode = be.StatusCode;
                        }
                        logger.LogError(ex, context.Request.Path + context.Request.QueryString);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new 
                        {
                            ErrorMessage = ex.Message
                        }));
                    }
                });
            });
            return app;
        }
    }
}
