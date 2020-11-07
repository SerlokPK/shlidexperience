using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        User EditUser(User user);
        User ChangeEmail(int userId, string newEmail, string password);
        UserReset ChangePassword(int userId, string password, string newPassword);
    }
}
