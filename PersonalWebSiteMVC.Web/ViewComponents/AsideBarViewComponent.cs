using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class AsideBarViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public AsideBarViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userService.GetFrontProfile();
            return View(user);
        }

    }
}
