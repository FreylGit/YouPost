using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Models;
using YouPost.Models.ViewModels;
using YouPost.Repositories.Interface;

namespace YouPost.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPost(NewPostModel model, ApplicationUser user)
        {
            Post post = new Post()
            {
                Title = model.Title,
                Text = model.Text,
                User = user,
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
       
        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public Post GetPost(Guid id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            return post;
        }

        public void UpdatePost(NewPostModel model)
        {
           
        }
    }
}
