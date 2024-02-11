using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
using Watchlist.ViewModels.UserViewModels;

namespace Watchlist.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerModel = new UserRegisterViewModel();

            return View(registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var user = new User() 
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }

            return RedirectToAction("All", "Movies");
        }

        public IActionResult Login()
        {
            var loginView = new UserLoginViewModel();

            return View(loginView);
        }
    }
}
