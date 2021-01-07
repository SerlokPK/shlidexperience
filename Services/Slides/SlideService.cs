using AutoMapper;
using Common.Helpers;
using DomainModels.Slides;
using DtoModels.Slides.Filters;
using DtoModels.Slides.Request;
using DtoModels.Slides.Response;
using Interfaces.Repositories;
using Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Services.Slides
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IMapper _mapper;

        public SlideService(ISlideRepository slideRepository, IMapper mapper)
        {
            DependencyHelper.ThrowIfNull(mapper, slideRepository);

            _slideRepository = slideRepository;
            _mapper = mapper;
        }

        public SlideDto CreateSlide(int presentationId)
        {
            var slide = _slideRepository.CreateSlide(presentationId);

            return _mapper.Map<SlideDto>(slide);
        }

        public SlideDto GetSlide(short slideId, int presentationId, Guid deviceId)
        {
            var slide = _slideRepository.GetSlide(slideId, presentationId, deviceId);

            return _mapper.Map<SlideDto>(slide);
        }

        public GetSlidesDto GetSlides(int presentationId, SlideFilter filter)
        {
            var slides = _slideRepository.GetSlides(presentationId, filter);
            var count = _slideRepository.GetSlidesCount(presentationId);

            return new GetSlidesDto
            {
                Slides = _mapper.Map<List<SlideDto>>(slides),
                Count = count
            };
        }

        public List<SlideType> GetTypes()
        {
            return _slideRepository.GetTypes();
        }

        public SlideDto EditSlide(EditSlideModel model)
        {
            var slide = _slideRepository.EditSlide(model.SlideId, model.PresentationId, model.Question, model.SlideType, _mapper.Map<List<SlideOption>>(model.SlideOptions));

            return _mapper.Map<SlideDto>(slide);
        }

        public void DeleteSlide(short slideId, int presentationId)
        {
            _slideRepository.DeleteSlide(slideId, presentationId);
        }
    }
}
