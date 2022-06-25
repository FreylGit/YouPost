using System.ComponentModel.DataAnnotations;

namespace YouPost.Models.ViewModels
{
    public class NewPostModel
    {
        [Required]
        [MaxLength(120)]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        public Guid UserId { get; set; }

        public NewPostModel()
        {

        }
        public NewPostModel(Guid id)
        {
            UserId = id;
        }
    }
}
