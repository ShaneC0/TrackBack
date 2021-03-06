﻿using System.ComponentModel.DataAnnotations;

namespace TrackBack.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public bool Completed { get; set; } = false;

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
