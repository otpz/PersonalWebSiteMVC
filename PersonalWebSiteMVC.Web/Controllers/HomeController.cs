using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.Models;
using System.Diagnostics;

namespace PersonalWebSiteMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetFrontProfile();

            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
