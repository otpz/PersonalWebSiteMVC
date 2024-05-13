using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public ContactInfoViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = userService.GetFrontProfile();

            return View(user);

        }
    }
}
