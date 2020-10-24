using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Account;
using Services.Account;
using Services.Mail;

namespace shlidexperience.helpers
{
    public static class RegisterAppServicesHelper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMailService, MailService>();
            return services;
        }

        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
