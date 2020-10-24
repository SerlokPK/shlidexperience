namespace Common
{
    public class AppSettings
    {
        public string ClientUrl { get; set; }
        public string JwtKey { get; set; }
        public string ConnectionString { get; set; }
        public string WebsiteUrl { get; set; }
        public string MailTemplatePath { get; set; }
        public string EmailSettingsFrom { get; set; }
        public string EmailSettingsFromName { get; set; }
        public string EmailSettingsHost { get; set; }
        public string EmailSettingsUsername { get; set; }
        public string EmailSettingsPassword { get; set; }
        public int EmailSettingsPort { get; set; }
        public bool EmailSettingsEnableSsl { get; set; }
        public int ResetKeyDurationInMinutes { get; set; }
    }
}
