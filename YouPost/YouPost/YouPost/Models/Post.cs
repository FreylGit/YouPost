using System.ComponentModel.DataAnnotations;
using YouPost.Areas.Identity.Data;

namespace YouPost.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
     
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
