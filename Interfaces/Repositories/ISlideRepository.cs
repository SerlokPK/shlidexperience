using DomainModels.Slides;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface ISlideRepository
    {
        List<SlideType> GetTypes();
    }
}
