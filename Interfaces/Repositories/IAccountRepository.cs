using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IAccountRepository
    {
        User Login(string email, string password);
        User Register(string email, string username, string password);
    }
}
