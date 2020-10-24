using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Users;
using DtoModels.Account.Response;
using DtoModels.User.Response;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.Options;

namespace Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountsRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AccountService(IAccountRepository accountRepository, IOptions<AppSettings> options, IMapper mapper)
        {
            DependencyHelper.ThrowIfNull(accountRepository, options, mapper);

            _accountsRepository = accountRepository;
            _appSettings = options.Value;
            _mapper = mapper;
        }
        public UserAuthDto Login(string email, string password)
        {
            var user = _accountsRepository.Login(email, password);
            var userAuth = new UserAuthDto
            {
                User = _mapper.Map<UserDto>(user)
            };
            if (user?.Status == UserStatus.Active.Status)
            {
                userAuth.Token = JwtTokenHelper.GenerateJSONWebToken(user, _appSettings.JwtKey);
            }

            return userAuth;
        }

        public UserDto Register(string email, string username, string password)
        {
            var registeredUser = _accountsRepository.Register(email, username, password);
            if (registeredUser != null)
            {
                var link = $"{_appSettings.WebsiteUrl}/account/activate/{registeredUser.UserKey}";
                //_mailService.RegisteredUserSendMail(languageSign, email, username, link);

                return _mapper.Map<UserDto>(registeredUser);
            }

            return null;
        }
    }
}
