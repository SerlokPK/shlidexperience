using AutoMapper;
using Common.Helpers;
using DomainModels.Users;
using DtoModels.User.Request;
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

        public void ChangeEmail(ChangeEmailModel model)
        {
            _userRepository.ChangeEmail(model.UserId, model.NewEmail, model.Password);
            // todo email
        }

        public void ChangePassword(ChangePasswordModel model)
        {
            _userRepository.ChangePassword(model.UserId, model.Password, model.NewPassword);
            // todo email
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
