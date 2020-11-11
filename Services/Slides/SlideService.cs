using AutoMapper;
using DomainModels.Slides;
using DtoModels.Slides.Response;
using Interfaces.Repositories;
using Interfaces.Services;
using System.Collections.Generic;

namespace Services.Slides
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IMapper _mapper;

        public SlideService(ISlideRepository slideRepository, IMapper mapper)
        {
            _slideRepository = slideRepository;
            _mapper = mapper;
        }

        public short CreateSlide(int presentationId)
        {
            return _slideRepository.CreateSlide(presentationId);
        }

        public SlideDto GetSlide(short slideId)
        {
            var slide = _slideRepository.GetSlide(slideId);

            return _mapper.Map<SlideDto>(slide);
        }

        public List<SlideDto> GetSlides(int presentationId)
        {
            var slides = _slideRepository.GetSlides(presentationId);

            return _mapper.Map<List<SlideDto>>(slides);
        }

        public List<SlideType> GetTypes()
        {
            return _slideRepository.GetTypes();
        }
    }
}
