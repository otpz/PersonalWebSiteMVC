using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Users;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginViewModel.Email);
                if(user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, false, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    } else
                    {
                        ModelState.AddModelError("", "E-posta veya şifreniz yanlış.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta veya şifreniz yanlış.");
                    return View();
                }

            } else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
