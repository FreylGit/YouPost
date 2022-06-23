using Microsoft.AspNetCore.Mvc;

namespace YouPost.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
