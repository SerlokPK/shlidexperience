using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("SlideOptions")]
    public class SlideOptionEntity
    {
        [Key]
        public Guid SlideOptionId { get; set; }

        [Required]
        public short SlideId { get; set; }

        [Required]
        [StringLength(255)]
        public string Text { get; set; }

        [Required]
        public int NumberOfAnswers { get; set; }

        [ForeignKey("SlideId")]
        public virtual SlideEntity Slide { get; set; }

        public virtual ICollection<OptionResultEntity> OptionResults { get; set; }
    }
}
