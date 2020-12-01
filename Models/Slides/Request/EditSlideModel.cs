using DomainModels.Slides;
using DtoModels.Slides.Response;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DtoModels.Slides.Request
{
    public class EditSlideModel
    {
        [Required]
        public short SlideId { get; set; }

        [Required]
        public int PresentationId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SlideType SlideType { get; set; }

        public ICollection<SlideOptionDto> SlideOptions { get; set; } = new List<SlideOptionDto>();
    }
}
