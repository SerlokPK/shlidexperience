using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Services.Mappings;

namespace shlidexperience.Helpers
{
    public static class AutoMapperHelper
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddAutoMapper(a => a.AddProfile<UserProfile>(), typeof(Startup));

            return services;
        }
    }
}
