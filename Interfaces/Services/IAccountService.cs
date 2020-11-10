using DtoModels.Account.Request;
using DtoModels.Account.Response;
using DtoModels.User.Response;

namespace Interfaces.Services
{
    public interface IAccountService
    {
        UserAuthDto Login(LoginModel model);
        UserDto Register(RegisterModel model);
        void ForgotPassword(string email);
        void ResetPassword(ResetPasswordModel model);
    }
}
