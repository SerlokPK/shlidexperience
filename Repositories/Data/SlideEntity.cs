using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("Slides")]
    public class SlideEntity
    {
        [Key]
        public short SlidetId { get; set; }

        [Required]
        public short SlideTypeId { get; set; }

        [ForeignKey("SlideTypeId")]
        public virtual SlideTypeEntity SlideType { get; set; }

        public virtual IEnumerable<SlideOptionEntity> SlideOptions { get; set; } = new List<SlideOptionEntity>();
    }
}
