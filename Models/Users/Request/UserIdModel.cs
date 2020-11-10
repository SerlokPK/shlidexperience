using System.ComponentModel.DataAnnotations;

namespace DtoModels.User.Request
{
    public class UserIdModel
    {
        [Required]
        public int UserId { get; set; }
    }
}
