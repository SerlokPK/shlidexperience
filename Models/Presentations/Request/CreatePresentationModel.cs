using System.ComponentModel.DataAnnotations;

namespace DtoModels.Presentations.Request
{
    public class CreatePresentationModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
