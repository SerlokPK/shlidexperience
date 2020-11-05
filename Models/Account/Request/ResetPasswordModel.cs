using Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace DtoModels.Account.Request
{
    public class ResetPasswordModel
    {
        [Required]
        public string ResetKey { get; set; }

        [Required]
        [RegularExpression(Regex.PasswordFormat)]
        [StringLength(20)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
