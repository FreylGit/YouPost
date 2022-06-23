using YouPost.Areas.Identity.Data;

namespace YouPost.Models.ViewModels
{
    public class FeedPostModel
    {
       IEnumerable<Post> Posts { get; set; }
       
    }
}
