using System.Collections.Generic;

namespace DtoModels.Slides.Response
{
    public class GetSlidesDto
    {
        public List<SlideDto> Slides { get; set; }
        public int Count { get; set; }
    }
}
