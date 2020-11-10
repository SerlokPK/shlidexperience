using System.Collections.Generic;

namespace DomainModels.Slides
{
    public class Slide
    {
        public short SlideId { get; set; }

        public virtual SlideType SlideType { get; set; }

        public virtual IEnumerable<SlideOption> SlideOptions { get; set; } = new List<SlideOption>();
    }
}
