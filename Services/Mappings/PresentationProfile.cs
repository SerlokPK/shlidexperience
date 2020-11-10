using AutoMapper;
using DomainModels.Presentations;
using DtoModels.Presentations.Response;
using Repositories.Data;
using System.Linq;

namespace Services.Mappings
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<PresentationEntity, Presentation>();
            CreateMap<Presentation, PresentationDto>();
            CreateMap<PresentationEntity, PresentationView>()
                .ForMember(dest => dest.SlideCount, src => src.MapFrom(x => x.Slides.Count()));
            CreateMap<PresentationView, PresentationViewDto>();
        }
    }
}
