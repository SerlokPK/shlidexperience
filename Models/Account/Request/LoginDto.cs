using System.ComponentModel.DataAnnotations;

namespace DtoModels.Account.Request
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
