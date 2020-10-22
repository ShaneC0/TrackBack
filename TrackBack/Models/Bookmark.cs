using System.ComponentModel.DataAnnotations;

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
