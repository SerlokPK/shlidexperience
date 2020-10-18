using DtoModels.User.Response;

namespace DtoModels.Account.Response
{
    public class UserAuthDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
