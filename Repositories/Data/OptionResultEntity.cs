using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("OptionResults")]
    public class OptionResultEntity
    {
        public short SlideId { get; set; }

        public Guid SlideOptionId { get; set; }

        public int UserId { get; set; }
        
        public SlideEntity Slide { get; set; }

        public SlideOptionEntity SlideOption { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}
