using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        void EditUser(User user);
        UserReset ChangeEmail(int userId, string newEmail, string password);
        UserReset ChangePassword(int userId, string password, string newPassword);
    }
}
