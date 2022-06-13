using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using YouPost.Data;
using YouPost.Models;

namespace YouPost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private  ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           // _context = context;
        }

        public IActionResult Index()
        {
           /* if (_context.Persons.Count()==0)
            {
                var p = new Person()
                {
                    FirstName = "Admin",
                    SecondName = "Developer",
                    NumberPhone = "99999999999",
                    Email = "admin@.com",
                    Password = "admin",
                    Photo = "img.jpg"

                };
                _context.Persons.Add(p);
                _context.SaveChanges();
            }*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}