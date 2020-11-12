using DomainModels.Slides;
using DtoModels.Slides.Request;
using DtoModels.Slides.Response;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface ISlideService
    {
        List<SlideType> GetTypes();
        short CreateSlide(int presentationId);
        List<SlideDto> GetSlides(int presentationId);
        SlideDto GetSlide(short slideId);
        SlideDto EditSlide(EditSlideModel model);
    }
}
