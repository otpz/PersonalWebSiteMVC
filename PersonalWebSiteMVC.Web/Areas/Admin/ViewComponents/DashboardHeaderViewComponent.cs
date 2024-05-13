using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.Areas.Admin.ViewComponents
{
    [Authorize(Roles="SuperAdmin")]
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly IUserService userService;
        public DashboardHeaderViewComponent(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userService.GetUserProfile();
            return View(user);
        }
    }
}
