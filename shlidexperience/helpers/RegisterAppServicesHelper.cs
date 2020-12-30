using Interfaces.Repositories;
using Interfaces.Services;
using Interfaces.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Account;
using Repositories.Options;
using Repositories.Presentations;
using Repositories.Slides;
using Repositories.UserRepo;
using Services.Account;
using Services.Mail;
using Services.Options;
using Services.Presentations;
using Services.Slides;
using Services.UserSer;
using SignalR;

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
            services.AddScoped<IOptionService, OptionService>();
            services.AddTransient<IVotingHubClient, VotingHub>();

            return services;
        }

        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPresentationRepository, PresentationRepository>();
            services.AddScoped<ISlideRepository, SlideRepository>();
            services.AddScoped<IOptionRepository, OptionRepository>();

            return services;
        }
    }
}
