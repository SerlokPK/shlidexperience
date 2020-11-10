using DomainModels.Slides;
using System.Collections.Generic;

namespace DomainModels.Presentations
{
    public class Presentation
    {
        public int PresentationId { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Slide> Slides { get; set; } = new List<Slide>();
    }
}
