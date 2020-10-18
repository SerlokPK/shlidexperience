using Common;
using Common.Helpers;
using DomainModels.Users;
using DtoModels.Account.Response;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.Options;

namespace Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountsRepository;
        private readonly AppSettings _appSettings;

        public AccountService(IAccountRepository accountRepository, IOptions<AppSettings> options)
        {
            _accountsRepository = accountRepository;
            _appSettings = options.Value;
        }
        public UserAuthDto Login(string email, string password)
        {
            var user = _accountsRepository.Login(email, password);
            if (user?.Status == UserStatus.Active.Status)
            {
                var token = JwtTokenHelper.GenerateJSONWebToken(user, _appSettings.JwtKey);

                return new UserAuthDto
                {
                    //User = user,
                    Token = token
                };
            }
            //throw new UnauthorizedException(Localization.Login_WrongCredentials);
            return null;
        }
    }
}
