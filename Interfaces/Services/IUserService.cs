using DtoModels.User.Response;

namespace Interfaces.Services
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);
    }
}
