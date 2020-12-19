using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("Devices")]
    public class DeviceEntity
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

        public DateTime Created { get; set; }
    }
}
