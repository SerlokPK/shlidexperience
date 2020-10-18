using Common;
using Common.Helpers;
using DomainModels.Users;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Repositories.Account
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(IOptions<AppSettings> config) : base(config)
        {
        }
        public User Login(string email, string password)
        {
            using (var context = GetContext())
            {
                if (string.IsNullOrEmpty(password))
                {
                    return null;
                }

                var user = context.Users.SingleOrDefault(x => x.Email == email);
                if (user == null)
                {
                    return null;
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
                    return null;
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
    }
}
