using AutoMapper;
using DomainModels.Slides;
using DtoModels.Slides.Response;
using Repositories.Data;

namespace Services.Mappings
{
    class SlideProfile : Profile
    {
        public SlideProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<SlideEntity, Slide>();
            CreateMap<Slide, SlideDto>();
            CreateMap<SlideOptionEntity, SlideOption>();
            CreateMap<SlideOption, SlideDto>();
        }
    }
}
