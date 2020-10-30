using AutoMapper;
using Common.Helpers;
using DtoModels.User.Response;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Services.UserSer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            DependencyHelper.ThrowIfNull(userRepository, mapper);

            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
