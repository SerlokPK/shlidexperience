namespace Interfaces.Services
{
    public interface IMailService
    {
        bool RegisteredUserMail(string languageSign, string email, string fullName, string link);
        bool AccountActivatedMail(string languageSign, string email, string fullName, string link);
        bool ResetPasswordMail(string languageSign, string email, string fullName, string link);
        bool ResetPasswordDoneMail(string languageSign, string email, string fullName, string link);
    }
}
