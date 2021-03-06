﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Data
{
    [Table("Presentations")]
    public class PresentationEntity
    {
        [Key]
        public int PresentationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<SlideEntity> Slides { get; set; } = new List<SlideEntity>();
    }
}
