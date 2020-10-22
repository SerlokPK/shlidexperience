using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
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
            _accountsRepository = accountRepository;
            _appSettings = options.Value;
            _mapper = mapper;
        }
        public UserAuthDto Login(string email, string password)
        {
            var user = _accountsRepository.Login(email, password);
            if (user?.Status == UserStatus.Active.Status)
            {
                var token = JwtTokenHelper.GenerateJSONWebToken(user, _appSettings.JwtKey);
                var userDto = _mapper.Map<UserDto>(user);

                return new UserAuthDto
                {
                    User = userDto,
                    Token = token
                };
            }
            
            throw new UnauthorizedException("Invalid email or username");
        }

        public UserDto Register(string email, string username, string password, string confirmPassword)
        {
            throw new System.NotImplementedException();
        }
    }
}
