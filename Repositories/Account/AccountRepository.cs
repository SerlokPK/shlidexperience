using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using DomainModels.Users;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Repositories.Constants;
using Repositories.Data;
using Repositories.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Repositories.Account
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        private const string _userDoesNotExist = "Invalid email or username";

        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AccountRepository(IOptions<AppSettings> config, IMapper mapper) : base(config)
        {
            DependencyHelper.ThrowIfNull(config, mapper);

            _appSettings = config.Value;
            _mapper = mapper;
        }

        public UserReset ForgotPassword(string email)
        {
            using (var context = GetContext())
            {
                if (string.IsNullOrEmpty(email))
                {
                    return null;
                }

                var user = context.Users.SingleOrDefault(x => x.Email == email);

                if (user != null)
                {
                    user.ResetKey = UuidHelper.GenerateUniqueKey(PasswordConstants.UniqueKeyLength);
                    user.ResetKeyTime = DateTime.Now.AddMinutes(_appSettings.ResetKeyDurationInMinutes);
                    context.SaveChanges();

                    return _mapper.Map<UserReset>(user);
                }

                return null;
            }
        }

        public User Login(string email, string password)
        {
            using (var context = GetContext())
            {
                var user = context.Users.SingleOrDefault(x => x.Email == email);
                if (user == null)
                {
                    throw new UnauthorizedException(_userDoesNotExist);
                }

                if (user.Status != UserStatus.Active.Status)
                {
                    return new User()
                    {
                        UserId = user.UserId,
                        Status = user.Status,
                    };
                }

                var shaPassword = HashHelper.Hash(user.PasswordSalt + password);
                if (!shaPassword.SequenceEqual(user.Password.ToArray()))
                {
                    throw new UnauthorizedException(_userDoesNotExist);
                }

                var userAuth = _mapper.Map<User>(user);

                user.LastLogin = DateTime.Now;

                context.SaveChanges();

                return userAuth;
            }
        }

        public User Register(string email, string firstName, string lastName, string password)
        {
            using (var context = GetContext())
            {
                if (context.Users.Any(u => u.Email == email))
                {
                    return null;
                }

                var saltPassword = PasswordHelper.GenerateRandomPassword(PasswordConstants.UniqueKeyLength, false, false);
                var shaPassword = HashHelper.Hash(saltPassword + password);

                var newUser = new Data.UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = shaPassword,
                    PasswordSalt = saltPassword,
                    Created = DateTime.Now,
                    Status = UserStatus.Active.Status,
                    UserKey = UuidHelper.GenerateUniqueKey(PasswordConstants.UniqueKeyLength),
                    Email = email,
                };

                var userEntity = context.Users.Add(newUser).Entity;
                context.SaveChanges();

                return _mapper.Map<User>(userEntity);
            }
        }

        public UserReset ResetPassword(string password, string resetKey)
        {
            using (var context = GetContext())
            {
                var saltPassword = PasswordHelper.GenerateRandomPassword(PasswordConstants.UniqueKeyLength, false, false);
                var shaPassword = HashHelper.Hash(saltPassword + password);

                var user = context.Users.SingleOrDefault(x => x.ResetKey == resetKey && x.Status == UserStatus.Active.Status);

                if (user != null && IsResetKeyValid(user.ResetKeyTime))
                {
                    user.PasswordSalt = saltPassword;
                    user.Password = shaPassword;
                    user.ResetKey = null;
                    user.ResetKeyTime = null;
                    context.SaveChanges();

                    return _mapper.Map<UserReset>(user);
                }

                return null;
            }
        }

        public void SaveDevice(string deviceId, int? userId)
        {
            using (var context = GetContext())
            {
                var guidDevice = new Guid(deviceId);
                var device = context.Devices.Find(guidDevice);

                if(device != null)
                {
                    if(device.UserId != userId)
                    {
                        device.UserId = userId;
                    }
                }else
                {
                    var entity = new DeviceEntity
                    {
                        UserId = userId,
                        Created = DateTime.Now
                    };
                    context.Devices.Add(entity);
                }

                context.SaveChanges();
            }
        }

        private bool IsResetKeyValid(DateTime? resetKeyTime)
        {
            return resetKeyTime != null && DateTime.Now < resetKeyTime;
        }
    }
}
