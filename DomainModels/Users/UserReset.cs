using System;

namespace DomainModels.Users
{
    public class UserReset
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ResetKey { get; set; }
        public DateTime? ResetKeyTime { get; set; }
    }
}
