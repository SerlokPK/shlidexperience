﻿using AutoMapper;
using Common;
using Common.Constants;
using Common.Helpers;
using DomainModels.Users;
using DtoModels.Account.Request;
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
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AccountService(IAccountRepository accountRepository, IOptions<AppSettings> options, IMapper mapper,
                               IMailService mailService)
        {
            DependencyHelper.ThrowIfNull(accountRepository, options, mapper, mailService);

            _accountsRepository = accountRepository;
            _mailService = mailService;
            _appSettings = options.Value;
            _mapper = mapper;
        }

        public void ForgotPassword(string email)
        {
            var user = _accountsRepository.ForgotPassword(email);
            if (user != null)
            {
                var link = $"{_appSettings.WebsiteUrl}/auth/forgot-password/{user.ResetKey}";
                _mailService.ResetPasswordMail(Language.DefaultSign, user.Email, user.FullName, link);
            }
        }

        public UserAuthDto Login(LoginModel model)
        {
            var user = _accountsRepository.Login(model.Email, model.Password);
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

        public UserDto Register(RegisterModel model)
        {
            var registeredUser = _accountsRepository.Register(model.Email, model.FirstName, model.LastName, model.Password);
            if (registeredUser != null)
            {
                _mailService.RegisteredUserMail(Language.DefaultSign, registeredUser.Email, $"{registeredUser.FirstName} {registeredUser.LastName}");

                return _mapper.Map<UserDto>(registeredUser);
            }

            return null;
        }

        public void ResetPassword(ResetPasswordModel model)
        {
            var user = _accountsRepository.ResetPassword(model.Password, model.ResetKey);
            if (user != null)
            {
                var link = $"{_appSettings.WebsiteUrl}/account/login";
                _mailService.ResetPasswordDoneMail(Language.DefaultSign, user.Email, user.FullName, link);
            }
        }

        public void SaveDevice(string deviceId, int? userId)
        {
            _accountsRepository.SaveDevice(deviceId, userId);
        }
    }
}
