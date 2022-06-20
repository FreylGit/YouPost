using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Models;
using YouPost.Models.ViewModels;
using YouPost.Repositories;

namespace YouPost.Controllers
{
    public class ProfileController : Controller
    {
        private PostRepository repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;  
        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager )
        {
            repository = new PostRepository(context);
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ApplicationUser  user = await _userManager.GetUserAsync(User);
            user.Posts = _context.Posts.Include(u => u.User).ToList();
            return View(user);
        }
        [HttpGet]
        public async Task< IActionResult> CreatePost()
        {

            NewPostModel model = new NewPostModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(NewPostModel model)
        {
            var user = await _userManager.GetUserAsync(User);
           
            repository.AddPost(model,user);
            return RedirectToAction("Index", "Profile");
        }
    }
}
