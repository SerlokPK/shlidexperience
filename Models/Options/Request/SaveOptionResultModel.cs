using System;
using System.ComponentModel.DataAnnotations;

namespace DtoModels.Options.Request
{
    public class SaveOptionResultModel
    {
        [Required]
        public short SlideId { get; set; }

        [Required]
        public Guid OptionId { get; set; }

        public Guid DeviceId { get; set; }
    }
}
