using Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace DtoModels.Account.Request
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(Regex.PasswordFormat)]
        [StringLength(20)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
