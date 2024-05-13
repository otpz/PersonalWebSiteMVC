using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class SkillViewComponent : ViewComponent
    {
        private readonly ITalentService talentService;

        public SkillViewComponent(ITalentService talentService)
        {
            this.talentService = talentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skills = await talentService.GetAllTalentsWithImageAsync();
            return View(skills);
        }
    }
}
