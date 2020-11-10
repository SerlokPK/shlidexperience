using DomainModels.Slides;
using System.Collections.Generic;

namespace DtoModels.Slides.Response
{
    public class SlideDto
    {
        public short SlideId { get; set; }

        public virtual SlideType SlideType { get; set; }

        public virtual IEnumerable<SlideOptionDto> SlideOptions { get; set; } = new List<SlideOptionDto>();
    }
}
