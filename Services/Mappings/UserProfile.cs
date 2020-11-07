using AutoMapper;
using DomainModels.Users;
using DtoModels.User.Request;
using DtoModels.User.Response;
using Repositories.Data;

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
            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.UserKey, opt => opt.Ignore());
            CreateMap<UserEntity, UserReset>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            CreateMap<EditUserModel, User>();
        }
    }
}
