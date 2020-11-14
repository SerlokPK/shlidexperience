using System.Collections.Generic;

namespace DomainModels.Slides
{
    public class Slide
    {
        public short SlideId { get; set; }

        public SlideType SlideType { get; set; }

        public ICollection<SlideOption> SlideOptions { get; set; } = new List<SlideOption>();
    }
}
