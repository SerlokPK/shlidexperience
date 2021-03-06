﻿using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using DomainModels.Users;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Repositories.Constants;
using Repositories.Data;
using Repositories.Helpers;
using System.Linq;

namespace Repositories.UserRepo
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            DependencyHelper.ThrowIfNull(options, mapper);

            _mapper = mapper;
        }

        public User ChangeEmail(int userId, string newEmail, string password)
        {
            using (var context = GetContext())
            {
                var dbUser = context.Users.SingleOrDefault(u => u.UserId == userId);

                if (dbUser == null)
                {
                    throw new NotFoundException("User entity not found");
                }

                var shaPassword = HashHelper.Hash(dbUser.PasswordSalt + password);
                if (!shaPassword.SequenceEqual(dbUser.Password.ToArray()))
                {
                    throw new UnauthorizedException("Invalid password");
                }

                var user = _mapper.Map<User>(dbUser);
                dbUser.Email = newEmail;

                context.SaveChanges();

                return user;
            }
        }

        public UserReset ChangePassword(int userId, string password, string newPassword)
        {
            using (var context = GetContext())
            {
                var dbUser = context.Users.SingleOrDefault(u => u.UserId == userId);

                if (dbUser == null)
                {
                    throw new NotFoundException("User entity not found");
                }

                var shaPassword = HashHelper.Hash(dbUser.PasswordSalt + password);
                if (!shaPassword.SequenceEqual(dbUser.Password.ToArray()))
                {
                    throw new UnauthorizedException("Invalid password");
                }

                var saltPassword = PasswordHelper.GenerateRandomPassword(PasswordConstants.UniqueKeyLength, false, false);
                shaPassword = HashHelper.Hash(saltPassword + password);

                dbUser.PasswordSalt = saltPassword;
                dbUser.Password = shaPassword;

                context.SaveChanges();

                return _mapper.Map<UserReset>(dbUser);
            }
        }

        public User EditUser(User user)
        {
            using (var context = GetContext())
            {
                var dbUser = context.Users.SingleOrDefault(u => u.UserId == user.UserId);

                if (dbUser == null)
                {
                    throw new NotFoundException("User entity not found");
                }

                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;

                context.SaveChanges();

                return GetUserById(context, user.UserId);
            }
        }

        public User GetUserById(int userId)
        {
            using (var context = GetContext())
            {
                return GetUserById(context, userId);
            }
        }

        private User GetUserById(ShlidexperienceContext context, int userId)
        {
            var user = context.Users.SingleOrDefault(u => u.UserId == userId);

            return _mapper.Map<User>(user);
        }
    }
}
