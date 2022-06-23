using Microsoft.AspNetCore.Mvc;
using YouPost.Data;
using YouPost.Models.ViewModels;
using YouPost.Repositories;

namespace YouPost.Controllers
{
    public class FeedController : Controller
    {
        private readonly UserRepository _repository;
        public FeedController(ApplicationDbContext context)
        {
            _repository = new UserRepository(context);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string username)
        {
            if(username != null)
            {
                var user = _repository.SearchByUsername(username);
                SearchUserModel model = new SearchUserModel();
                model.ToModel(user);
                return View(model);
            }
            return View();
        }
       
    }
}
