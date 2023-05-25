namespace Watchlist.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model=new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid || registerModel.Password!=registerModel.ConfirmPassword)
            {
                return View(registerModel);
            }

            var user = new User
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email
            };

            var findUser = await userManager.FindByNameAsync(user.UserName);
            if (findUser != null)
            {
                return View(registerModel);
            }

            var findEmail = await userManager.FindByEmailAsync(user.Email);
            if (findEmail != null)
            {
                return View(registerModel);
            }

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return View(registerModel);
            }

            return await SignInRedirection(user,"Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            User user = await userManager.FindByNameAsync(loginModel.UserName);
            if (user == null)
            {
                return View(loginModel);
            }

            var passwordValidator = await userManager.CheckPasswordAsync(user, loginModel.Password);
            if (passwordValidator == false)
            {
                return View(loginModel);
            }

            await signInManager.SignInAsync(user,isPersistent:false);
            return RedirectToAction();
        }

        private async Task<IActionResult> SignInRedirection(User user, string action, string controller)
        {
            await signInManager.SignInAsync(user, false);
            return RedirectToAction(action, controller);
        }
    }
}