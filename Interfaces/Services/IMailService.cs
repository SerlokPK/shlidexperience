namespace Interfaces.Services
{
    public interface IMailService
    {
        bool RegisteredUserSendMail(string languageSign, string email, string fullName, string link);
        bool AccountActivatedSendMail(string languageSign, string email, string fullName, string link);
        bool ResetPasswordSendMail(string languageSign, string email, string fullName, string link);
        bool ResetPasswordDoneSendMail(string languageSign, string email, string fullName, string link);
    }
}
