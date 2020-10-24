using Common;
using Common.Helpers;
using Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace Services.Mail
{
    public class MailService : IMailService
    {
        private readonly Dictionary<string, string> MailTemplatesDict = new Dictionary<string, string>();
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        public MailService(IOptions<AppSettings> options, ILogger logger)
        {
            DependencyHelper.ThrowIfNull(options, logger);

            _appSettings = options.Value;
            _logger = logger;
        }

        public bool AccountActivatedMail(string languageSign, string email, string fullName, string link)
        {
            throw new System.NotImplementedException();
        }

        public bool RegisteredUserMail(string languageSign, string email, string fullName, string link)
        {
            var body = CreateEmailBody(languageSign, "UserRegistered");
            body = body.Replace("{name}", fullName);
            body = body.Replace("{link}", link);
            var mailSubject = "Successful registration";

            return SendEmailWithAttachment(languageSign, email, mailSubject, true, body, null, null, null);
        }

        public bool ResetPasswordDoneMail(string languageSign, string email, string fullName, string link)
        {
            throw new System.NotImplementedException();
        }

        public bool ResetPasswordMail(string languageSign, string email, string fullName, string link)
        {
            throw new System.NotImplementedException();
        }

        private string CreateEmailBody(string languageSign, string template)
        {
            if (!string.IsNullOrEmpty(languageSign) && !string.IsNullOrEmpty(template))
            {
                try
                {
                    using (StreamReader reader = new StreamReader($"{_appSettings.MailTemplatePath}/{languageSign}/{template}.html", Encoding.Default))
                    {
                        var body = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(body))
                        {
                            return body;
                        }
                        else
                        {
                            _logger.LogError($"Email template {template} for language {languageSign} is empty.");
                            return string.Empty;
                        }
                    }
                }
                catch (Exception exc)
                {
                    _logger.LogError(exc, $"Problem finding email template: {template} for language {languageSign}.");
                }
            }
            return string.Empty;
        }

        private string GetMailTemplate(string languageSign)
        {
            lock (MailTemplatesDict)
            {
                if (MailTemplatesDict.ContainsKey(languageSign))
                {
                    return MailTemplatesDict[languageSign];
                }
            }
            var layout = CreateEmailBody(languageSign, "_EmailLayout");
            lock (MailTemplatesDict)
            {
                if (MailTemplatesDict.ContainsKey(languageSign))
                {
                    MailTemplatesDict[languageSign] = layout;
                }
                else
                {
                    MailTemplatesDict.Add(languageSign, layout);
                }
            }
            return layout;
        }

        private bool SendEmailWithAttachment(string languageSign, string to, string subject, bool isBodyHtml, string body, string filePath, byte[] dataAttachment, string replyTo)
        {
            if (string.IsNullOrEmpty(body))
            {
                _logger.LogError("SendEmailWithAttacment - No email body.");

                return false;
            }
            var layout = GetMailTemplate(languageSign);
            layout = layout.Replace("{body}", body);

            var mail = new DomainModels.Mail.Mail
            {
                To = to,
                Subject = subject,
                IsBodyHtml = isBodyHtml,
                Body = layout,
                AttachmentPath = filePath,
                AttachmentData = dataAttachment,
                ReplayTo = replyTo,
                From = _appSettings.EmailSettingsFrom,
                FromName = _appSettings.EmailSettingsFromName,
                Host = _appSettings.EmailSettingsHost,
                Username = _appSettings.EmailSettingsUsername,
                Pass = _appSettings.EmailSettingsPassword,
                Port = _appSettings.EmailSettingsPort,
                EnableSsl = _appSettings.EmailSettingsEnableSsl
            };


            if (!string.IsNullOrEmpty(mail.From) && !string.IsNullOrEmpty(mail.Host) && !string.IsNullOrEmpty(mail.Username) && !string.IsNullOrEmpty(mail.Pass))
            {
                SendEmailWithAttachment(mail);

                return true;
            }

            _logger.LogWarning("Mail not configured.");

            return false;
        }

        private bool SendEmailWithAttachment(DomainModels.Mail.Mail mail)
        {
            try
            {
                var smtp = new SmtpClient(mail.Host, mail.Port)
                {
                    EnableSsl = mail.EnableSsl,
                    Credentials = new System.Net.NetworkCredential(mail.Username, mail.Pass),
                };

                MailAddress fromAddress = new MailAddress(mail.From, mail.FromName);
                MailAddress toAddress = new MailAddress(mail.To);

                var email = new MailMessage(fromAddress, toAddress)
                {
                    Subject = mail.Subject,
                    Body = mail.Body,
                    IsBodyHtml = mail.IsBodyHtml
                };
                if (!string.IsNullOrEmpty(mail.ReplayTo))
                {
                    email.ReplyToList.Add(mail.ReplayTo);
                }
                if (!string.IsNullOrEmpty(mail.AttachmentPath))
                {
                    var atch = new Attachment(mail.AttachmentPath);
                    email.Attachments.Add(atch);
                }
                if (mail.AttachmentData != null)
                {
                    Stream streamData = new MemoryStream(mail.AttachmentData);
                    var atch = new Attachment(streamData, "byteAttachment");
                    email.Attachments.Add(atch);
                }
                smtp.Send(email);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}
