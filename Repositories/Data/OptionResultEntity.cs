using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("OptionResults")]
    public class OptionResultEntity
    {
        public short SlideId { get; set; }

        public Guid SlideOptionId { get; set; }

        public Guid DeviceId { get; set; }
        
        public SlideEntity Slide { get; set; }

        public SlideOptionEntity SlideOption { get; set; }

        public DeviceEntity Device { get; set; }
    }
}
