using DomainModels.Slides;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface ISlideService
    {
        List<SlideType> GetTypes();
    }
}
