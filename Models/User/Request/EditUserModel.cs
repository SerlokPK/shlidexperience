using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class EditUserModel : UserIdModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
