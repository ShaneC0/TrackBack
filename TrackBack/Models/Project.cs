using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackBack.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public List<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

        public List<Todo> Todos { get; set; } = new List<Todo>();
    }
}
