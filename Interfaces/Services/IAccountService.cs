using DtoModels.Account.Response;
using DtoModels.User.Response;

namespace Interfaces.Services
{
    public interface IAccountService
    {
        UserAuthDto Login(string email, string password);
        UserDto Register(string email, string username, string password, string confirmPassword);
    }
}
