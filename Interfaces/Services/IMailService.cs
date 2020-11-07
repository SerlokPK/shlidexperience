namespace Interfaces.Services
{
    public interface IMailService
    {
        bool RegisteredUserMail(string languageSign, string email, string fullName);
        bool ResetPasswordMail(string languageSign, string email, string fullName, string link);
        bool ResetPasswordDoneMail(string languageSign, string email, string fullName, string link);
        bool ChangeEmailMail(string languageSign, string email, string newEmail, string fullName);
        bool PasswordChangedMail(string languageSign, string email, string fullName, string link);
    }
}
