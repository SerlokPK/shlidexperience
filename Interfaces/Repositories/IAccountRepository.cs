using DomainModels.Users;

namespace Interfaces.Repositories
{
    public interface IAccountRepository
    {
        User Login(string email, string password);
        User Register(string email, string firstName, string lastName, string password);
        UserReset ForgotPassword(string email);
        UserReset ResetPassword(string password, string resetKey);
        void SaveDevice(string deviceId, int? userId);
    }
}
