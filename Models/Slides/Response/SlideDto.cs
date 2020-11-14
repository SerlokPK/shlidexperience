using DomainModels.Slides;
using System.Collections.Generic;

namespace DtoModels.Slides.Response
{
    public class SlideDto
    {
        public short SlideId { get; set; }

        public SlideType SlideType { get; set; }

        public ICollection<SlideOptionDto> SlideOptions { get; set; } = new List<SlideOptionDto>();
    }
}
