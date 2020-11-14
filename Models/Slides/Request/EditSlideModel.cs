using DomainModels.Slides;
using DtoModels.Slides.Response;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DtoModels.Slides.Request
{
    public class EditSlideModel
    {
        [Required]
        public short SlideId { get; set; }

        [Required]
        public int PresentationId { get; set; }

        [Required]
        public SlideType Type { get; set; }

        public ICollection<SlideOptionDto> SlideOptions { get; set; } = new List<SlideOptionDto>();
    }
}
