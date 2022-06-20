using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using YouPost.Data;
using YouPost.Models;

namespace YouPost.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
           
        }
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