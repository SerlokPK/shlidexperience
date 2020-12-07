using DomainModels.Slides;
using DtoModels.Slides.Request;
using DtoModels.Slides.Response;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface ISlideService
    {
        List<SlideType> GetTypes();
        SlideDto CreateSlide(int presentationId);
        List<SlideDto> GetSlides(int presentationId);
        SlideDto GetSlide(short slideId, int presentationId);
        SlideDto EditSlide(EditSlideModel model);
    }
}
