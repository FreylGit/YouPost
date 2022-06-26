using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Models.ViewModels;
using YouPost.Repositories;

namespace YouPost.Controllers
{
    public class ProfileController : Controller
    {
        private readonly PostRepository _repositoryRole;
        private readonly UserRepository _repositoryUser;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _repositoryRole = new PostRepository(context);
            _repositoryUser = new UserRepository(context);
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string username)
        {
            if (username == null)
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    user.Posts = _context.Posts.Include(u => u.User).ToList();

                    return View(user);
                }
                user = _repositoryUser.GetUsers().First();

                return View(user);
            }
            else
            {
                var user = _repositoryUser.SearchByUsername(username);

                if (user != null)
                {
                    return View(user);
                }

                return RedirectToAction("Home", "Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreatePost()
        {
            NewPostModel model = new NewPostModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(NewPostModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            _repositoryRole.AddPost(model, user);

            return RedirectToAction("Index", "Profile");
        }
        [HttpGet]
        public async Task<IActionResult>Follow(string username)
        {
            return RedirectToAction("Index", "Profile");
        }

    }
}
