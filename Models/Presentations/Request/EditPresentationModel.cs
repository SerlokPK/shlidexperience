using System.ComponentModel.DataAnnotations;

namespace DtoModels.Presentations.Request
{
    public class EditPresentationModel
    {
        [Required]
        public int PresentationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
