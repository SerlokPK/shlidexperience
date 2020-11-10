using AutoMapper;
using DomainModels.Presentations;
using DtoModels.Presentations.Response;
using Repositories.Data;

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
        }
    }
}
