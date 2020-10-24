using AutoMapper;
using DomainModels.Users;
using DtoModels.User.Response;

namespace Services.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<User, UserDto>();
        }
    }
}
