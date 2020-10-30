using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Account;
using Repositories.UserRepo;
using Services.Account;
using Services.Mail;
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

            return services;
        }

        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
