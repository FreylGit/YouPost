using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YouPost.Controllers
{
    public class HomeController : Controller
    {

        [Authorize(Roles = "user")]
        public IActionResult Index()
        {

            return View();
        }

        [Authorize(Roles = "user,admin")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}