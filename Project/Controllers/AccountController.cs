using BusinessLayer;
using DataLayer.Enums;
using PresentationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models.View;
using System.Security.Claims;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private DataManager _dataManager;

        public AccountController(IAccountService accountService, DataManager dataManager)
        {
            _dataManager = dataManager;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [Route("/Account/Register", Name = "Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);
                if (response.StatusCode == DataLayer.Enums.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return Redirect("https://localhost:7145/User");
                }
                ModelState.AddModelError("", response.Description);
            }

            return Redirect("https://localhost:7145/Register");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [Route("/Account/Login", Name = "Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);
                if (response.StatusCode == DataLayer.Enums.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    var user = _dataManager.UserRepository.GetUserByLogin(model.Login);

                    if (user.Role.Equals(Role.Admin))
                    {
                        return Redirect("https://localhost:7145/Admin");
                    }
                    else if(user.Role.Equals(Role.User)){
                        return Redirect("https://localhost:7145/User");
                    }
                    
                }
                ModelState.AddModelError("", response.Description);
            }
            return Redirect("https://localhost:7145");
        }

        [ValidateAntiForgeryToken]
        [Route("/Account/Logout", Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("https://localhost:7145");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
