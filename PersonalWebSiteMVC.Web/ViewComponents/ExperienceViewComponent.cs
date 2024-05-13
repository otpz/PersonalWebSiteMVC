using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class ExperienceViewComponent : ViewComponent
    {
        private readonly IExperienceService experienceService;

        public ExperienceViewComponent(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var experiences = await experienceService.GetAllExperiencesAsync();
            return View(experiences);
        }
    }
}
