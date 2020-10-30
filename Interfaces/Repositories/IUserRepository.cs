using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
    }
}
