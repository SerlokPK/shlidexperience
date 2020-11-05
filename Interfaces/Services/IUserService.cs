using DtoModels.User.Request;
using DtoModels.User.Response;

namespace Interfaces.Services
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);
        void EditUser(EditUserModel model);
        void ChangeEmail(ChangeEmailModel model);
        void ChangePassword(ChangePasswordModel model);
    }
}
