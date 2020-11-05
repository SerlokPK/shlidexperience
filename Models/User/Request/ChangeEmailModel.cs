using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class ChangeEmailModel : UserIdModel
    {
        [Required]
        [EmailAddress]
        public string NewEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
