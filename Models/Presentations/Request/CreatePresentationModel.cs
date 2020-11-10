using System.ComponentModel.DataAnnotations;

namespace DtoModels.Presentations.Request
{
    public class CreatePresentationModel
    {
        [Required]
        public string Name { get; set; }
    }
}
