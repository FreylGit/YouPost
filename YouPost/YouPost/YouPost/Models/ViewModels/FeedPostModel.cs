using YouPost.Areas.Identity.Data;

namespace YouPost.Models.ViewModels
{
    //TODO: Потом подумаю хуйня какаято получается ща
    public class FeedPostModel
    {
       IEnumerable<Post> Posts { get; set; }
       
    }
}
