using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly IEducationService educationService;
        private readonly IValidator<EducationAddViewModel> validator;
        private readonly IToastNotification toastNotification;

        public EducationController(IEducationService educationService, IMapper mapper, IValidator<EducationAddViewModel> validator, IToastNotification toastNotification)
        {
            this.educationService = educationService;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var educations = await educationService.GetAllEducationsAsync();

            return View(educations);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EducationAddViewModel educationAddViewModel)
        {
            var validationResult = await validator.ValidateAsync(educationAddViewModel);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Ekleme işlemi tamamlanamadı", new ToastrOptions { Title = "Hata" });
            }

            var educationTitle = await educationService.CreateEducationAsync(educationAddViewModel);
            toastNotification.AddSuccessToastMessage(Messages.Education.Add(educationTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Education", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int educationId)
        {
            var educationTitle = await educationService.SafeDeleteEducationAsync(educationId);

            toastNotification.AddSuccessToastMessage(Messages.Education.Delete(educationTitle), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "Education", new { Area = "Admin" });
        }

    }
}
