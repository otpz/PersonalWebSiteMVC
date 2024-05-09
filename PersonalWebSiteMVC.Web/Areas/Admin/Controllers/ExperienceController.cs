using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.Experiences;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService experienceService;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<ExperienceAddViewModel> validator;

        public ExperienceController(IExperienceService experienceService, IToastNotification toastNotification, IValidator<ExperienceAddViewModel> validator)
        {
            this.experienceService = experienceService;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var experiences = await experienceService.GetAllExperiencesAsync();
            return View(experiences);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExperienceAddViewModel experienceAddViewModel)
        {
            var validatorResult = await validator.ValidateAsync(experienceAddViewModel);
            if (!validatorResult.IsValid)
            {
                validatorResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi.", new ToastrOptions { Title = "Hata" });
                return View();
            }
            string experienceTitle = await experienceService.CreateExperienceAsync(experienceAddViewModel);
            toastNotification.AddSuccessToastMessage(Messages.Experience.Add(experienceTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Experience", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int experienceId)
        {
            string experienceTitle = await experienceService.SafeDeleteExperienceAsync(experienceId);
            toastNotification.AddSuccessToastMessage(Messages.Experience.Delete(experienceTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Experience", new { Area = "Admin" });
        }

    }
}
