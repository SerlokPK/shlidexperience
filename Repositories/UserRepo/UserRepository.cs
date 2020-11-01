using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Users;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Repositories.UserRepo
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserRepository(IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            DependencyHelper.ThrowIfNull(options, mapper);

            _appSettings = options.Value;
            _mapper = mapper;
        }

        public User GetUserById(int userId)
        {
            using (var context = GetContext())
            {
                var user = context.Users.SingleOrDefault(u => u.UserId == userId);
                
                return _mapper.Map<User>(user);            
            }
        }
    }
}
