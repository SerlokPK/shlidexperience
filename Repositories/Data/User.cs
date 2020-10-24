using System;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public byte[] Password { get; set; }

        [Required]
        [StringLength(32)]
        public string PasswordSalt { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [Required]
        [StringLength(32)]
        public string UserKey { get; set; }

        [StringLength(32)]
        public string ResetKey { get; set; }

        public DateTime? ResetKeyTime { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
