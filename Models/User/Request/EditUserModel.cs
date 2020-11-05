using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class EditUserModel : UserIdModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
