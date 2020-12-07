using AutoMapper;
using DomainModels.Slides;
using DtoModels.Slides.Response;
using Repositories.Data;

namespace Services.Mappings
{
    public class SlideProfile : Profile
    {
        public SlideProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<SlideEntity, Slide>()
               .ForMember(dest => dest.SlideType, opt => opt.MapFrom(x => (SlideType)x.SlideTypeId));
            CreateMap<Slide, SlideDto>();
            CreateMap<SlideOptionEntity, SlideOption>();
            CreateMap<SlideOption, SlideDto>();
            CreateMap<SlideOptionDto, SlideOption>();
            CreateMap<SlideOption, SlideOptionDto>();
        }
    }
}
