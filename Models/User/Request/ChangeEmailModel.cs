using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class ChangeEmailModel : UserIdModel
    {
        [Required]
        [EmailAddress]
        public string NewEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
