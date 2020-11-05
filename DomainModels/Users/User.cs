using System;

namespace DomainModels.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string UserKey { get; set; }
        public DateTime Created { get; set; }
    }
}
