using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackBack.Models
{
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
