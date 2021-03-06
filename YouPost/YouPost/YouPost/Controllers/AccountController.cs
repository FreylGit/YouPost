using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Models.ViewModels;
using YouPost.Repositories;
using YouPost.Repositories.Interface;

namespace YouPost.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IUserRepository _repository;

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IUserStore<ApplicationUser> userStore,ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
            _repository = new UserRepository(context);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterModel model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.UserName,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    LastName = "",
                    Photo = "default",
                    Url = model.UserName,
                };

                await _userStore.SetUserNameAsync(user, model.UserName, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _repository.GetUsers().FirstOrDefault(u=> u.Email==model.Email);
                if (user == null)
                {
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверная попытка входа.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
