using YouPost.Areas.Identity.Data;
using YouPost.Models;
using YouPost.Models.ViewModels;

namespace YouPost.Repositories.Interface
{
    public interface IPostRepository
    {
        public void AddPost(NewPostModel model,ApplicationUser user);
        public void UpdatePost(NewPostModel post);
        public void DeletePost(Post model);
        public Post GetPost(Guid id);
    }
}
