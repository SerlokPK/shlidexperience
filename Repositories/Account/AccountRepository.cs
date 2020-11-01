using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using DomainModels.Users;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Repositories.Constants;
using Repositories.Helpers;
using System;
using System.Linq;

namespace Repositories.Account
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        private readonly AppSettings _appSettings;
        public AccountRepository(IOptions<AppSettings> config) : base(config)
        {
            DependencyHelper.ThrowIfNull(config);

            _appSettings = config.Value;
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

                    return new UserReset()
                    {
                        FullName = $"{user.FirstName} {user.LastName}",
                        Email = user.Email,
                        ResetKey = user.ResetKey,
                        ResetKeyTime = user.ResetKeyTime
                    };
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
                    throw new UnauthorizedException("Invalid email or username");
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
                    throw new UnauthorizedException("Invalid email or username");
                }

                var userAuth = new User
                {
                    UserId = user.UserId,
                    Status = user.Status,
                    Email = user.Email,
                    FullName = $"{user.FirstName} {user.LastName}"
                };

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

                return new User
                {
                    UserId = userEntity.UserId,
                    UserKey = newUser.UserKey,
                    Email = newUser.Email,
                    FullName = $"{newUser.FirstName} {newUser.LastName}",
                    Status = newUser.Status
                };
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

                    return new UserReset
                    {
                        FullName = $"{user.FirstName} {user.LastName}",
                        Email = user.Email
                    };
                }

                return null;
            }
        }

        private bool IsResetKeyValid(DateTime? resetKeyTime)
        {
            return resetKeyTime != null && DateTime.Now < resetKeyTime;
        }
    }
}
