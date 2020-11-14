using DomainModels.Slides;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface ISlideRepository
    {
        List<SlideType> GetTypes();
        short CreateSlide(int presentationId);
        List<Slide> GetSlides(int presentationId);
        Slide GetSlide(short slideId, int presentationId);
        Slide EditSlide(short slideId, int presentationId, SlideType type, List<SlideOption> slideOptions);
    }
}
