using DomainModels.Slides;
using DtoModels.Slides.Filters;
using System;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface ISlideRepository
    {
        List<SlideType> GetTypes();
        Slide CreateSlide(int presentationId);
        List<Slide> GetSlides(int presentationId, SlideFilter filter);
        int GetSlidesCount(int presentationId);
        Slide GetSlide(short slideId, int presentationId, Guid deviceId);
        Slide EditSlide(short slideId, int presentationId, string question, SlideType type, List<SlideOption> slideOptions);
        void DeleteSlide(short slideId, int presentationId);
    }
}
