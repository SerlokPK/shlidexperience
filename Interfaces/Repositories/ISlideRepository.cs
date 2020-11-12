﻿using DomainModels.Slides;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface ISlideRepository
    {
        List<SlideType> GetTypes();
        short CreateSlide(int presentationId);
        List<Slide> GetSlides(int presentationId);
        Slide GetSlide(short slideId);
        Slide EditSlide(short slideId, SlideType type, List<SlideOption> slideOptions);
    }
}
