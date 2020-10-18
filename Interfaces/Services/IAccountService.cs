using DtoModels.Account.Response;

namespace Interfaces.Services
{
    public interface IAccountService
    {
        UserAuthDto Login(string email, string password);
    }
}
