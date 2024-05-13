using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class EducationViewComponent : ViewComponent
    {
        private readonly IEducationService educationService;

        public EducationViewComponent(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educations = await educationService.GetAllEducationsAsync();
            return View(educations);
        }
    }
}
