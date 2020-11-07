using DtoModels.User.Request;
using DtoModels.User.Response;

namespace Interfaces.Services
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);
        UserDto EditUser(EditUserModel model);
        UserDto ChangeEmail(ChangeEmailModel model);
        void ChangePassword(ChangePasswordModel model);
    }
}
