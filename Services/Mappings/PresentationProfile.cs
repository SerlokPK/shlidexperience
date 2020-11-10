using AutoMapper;
using DomainModels.Presentations;
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
        }
    }
}
