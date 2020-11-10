using DtoModels.Slides.Response;
using System.Collections.Generic;

namespace DtoModels.Presentations.Response
{
    public class PresentationDto
    {
        public int PresentationId { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<SlideDto> Slides { get; set; } = new List<SlideDto>();
    }
}
