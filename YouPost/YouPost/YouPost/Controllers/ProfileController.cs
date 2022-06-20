using Microsoft.AspNetCore.Mvc;

namespace YouPost.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
