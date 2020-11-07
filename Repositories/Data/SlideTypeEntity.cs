using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("SlideTypes")]
    public class SlideTypeEntity
    {
        [Key]
        public short SlideTypeId { get; set; }

        [Required]
        public SlideType Type { get; set; }
    }
}
