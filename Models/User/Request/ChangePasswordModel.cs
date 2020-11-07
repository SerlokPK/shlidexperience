using Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class ChangePasswordModel : UserIdModel
    {
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(Regex.PasswordFormat)]
        [StringLength(20)]
        public string NewPassword { get; set; }
    }
}
