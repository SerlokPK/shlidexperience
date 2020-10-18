using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IAccountRepository
    {
        User Login(string email, string password);
        //RegisteredUser Register(string email, string username, string password, string confirmPassword);
    }
}
