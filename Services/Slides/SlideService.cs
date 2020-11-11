using DomainModels.Slides;
using Interfaces.Repositories;
using Interfaces.Services;
using System.Collections.Generic;

namespace Services.Slides
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public List<SlideType> GetTypes()
        {
            return _slideRepository.GetTypes();
        }
    }
}
