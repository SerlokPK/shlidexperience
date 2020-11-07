﻿using AutoMapper;
using Common;
using Common.Constants;
using Common.Helpers;
using DomainModels.Users;
using DtoModels.User.Request;
using DtoModels.User.Response;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.Options;

namespace Services.UserSer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IMapper mapper, IMailService mailService,
                            IOptions<AppSettings> options)
        {
            DependencyHelper.ThrowIfNull(userRepository, mapper, mailService, options);

            _userRepository = userRepository;
            _mapper = mapper;
            _mailService = mailService;
            _appSettings = options.Value;
        }

        public void ChangeEmail(ChangeEmailModel model)
        {
            var user =_userRepository.ChangeEmail(model.UserId, model.NewEmail, model.Password);
            if(user != null)
            {
                _mailService.ChangeEmailMail(Language.DefaultSign, user.Email, user.FullName);
            }
        }

        public void ChangePassword(ChangePasswordModel model)
        {
            var user = _userRepository.ChangePassword(model.UserId, model.Password, model.NewPassword);
            if(user != null)
            {
                var link = $"{_appSettings.WebsiteUrl}/auth/login";
                _mailService.PasswordChangedMail(Language.DefaultSign, user.Email, user.FullName, link);
            }
        }

        public void EditUser(EditUserModel model)
        {
            var user = _mapper.Map<User>(model);
            _userRepository.EditUser(user);
        }

        public UserDto GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
