namespace DomainModels.Mail
{
    public class Mail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Body { get; set; }
        public string AttachmentPath { get; set; }
        public byte[] AttachmentData { get; set; }
        public string ReplayTo { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public string Pass { get; set; }
        public string Username { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
