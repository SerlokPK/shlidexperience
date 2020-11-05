using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class ChangePasswordModel : UserIdModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
