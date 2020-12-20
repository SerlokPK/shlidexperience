using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("Devices")]
    public class DeviceEntity
    {
        [Key]
        public Guid Id { get; set; }

        public int? UserId { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}
