using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
