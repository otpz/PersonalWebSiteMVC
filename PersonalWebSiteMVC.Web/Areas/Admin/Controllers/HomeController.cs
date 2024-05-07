using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUserAsync();
            return View(users);
        }
    }
}
