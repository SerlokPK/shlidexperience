using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        void EditUser(User user);
        void ChangeEmail(int userId, string newEmail, string password);
        void ChangePassword(int userId, string password, string newPassword);
    }
}
