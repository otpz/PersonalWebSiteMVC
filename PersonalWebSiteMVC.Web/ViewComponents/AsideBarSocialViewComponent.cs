using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class AsideBarSocialViewComponent : ViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        public AsideBarSocialViewComponent(ISocialMediaService socialMediaService)
        {
            this.socialMediaService = socialMediaService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socials = await socialMediaService.GetAllSocialMediasWithImageAsync();
            return View(socials);
        }
    }
}
