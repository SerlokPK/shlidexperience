using Microsoft.Extensions.DependencyInjection;

namespace shlidexperience.helpers
{
    public static class RegisterAppCorsHelper
    {
        public const string AppCorsPolicyName = "ShlidexperienceAppCors";

        public static IServiceCollection RegisterAppCors(this IServiceCollection services, string clientUrl)
        {
            var urls = clientUrl.Split(',');
            services.AddCors(options =>
            {
                options.AddPolicy(AppCorsPolicyName,
                builder =>
                {
                    builder.WithOrigins(urls);
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
