using DomainModels.Slides;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DtoModels.Slides.Response
{
    public class SlideDto
    {
        public short SlideId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SlideType SlideType { get; set; }

        public string Question { get; set; }

        public bool HasAnswered { get; set; }

        public ICollection<SlideOptionDto> SlideOptions { get; set; } = new List<SlideOptionDto>();
    }
}
