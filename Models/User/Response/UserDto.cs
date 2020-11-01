using System;

namespace DtoModels.User.Response
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}
