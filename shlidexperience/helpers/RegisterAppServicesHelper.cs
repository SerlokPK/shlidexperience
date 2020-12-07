using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Account;
using Repositories.Presentations;
using Repositories.Slides;
using Repositories.UserRepo;
using Services.Account;
using Services.Mail;
using Services.Presentations;
using Services.Slides;
using Services.UserSer;

namespace shlidexperience.helpers
{
    public static class RegisterAppServicesHelper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPresentationService, PresentationService>();
            services.AddScoped<ISlideService, SlideService>();

            return services;
        }

        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPresentationRepository, PresentationRepository>();
            services.AddScoped<ISlideRepository, SlideRepository>();

            return services;
        }
    }
}
