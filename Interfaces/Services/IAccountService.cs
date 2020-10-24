using DtoModels.Account.Request;
using DtoModels.Account.Response;
using DtoModels.User.Response;

namespace Interfaces.Services
{
    public interface IAccountService
    {
        UserAuthDto Login(LoginDto model);
        UserDto Register(RegisterDto model);
    }
}
