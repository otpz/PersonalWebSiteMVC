using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.Entities;
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
        private readonly IMapper mapper;
        private readonly IValidator<Education> validator;
        private readonly IToastNotification toastNotification;

        public EducationController(IEducationService educationService, IMapper mapper, IValidator<Education> validator, IToastNotification toastNotification)
        {
            this.educationService = educationService;
            this.mapper = mapper;
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
            var map = mapper.Map<Education>(educationAddViewModel);
            var validationResult = await validator.ValidateAsync(map);

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
        public async Task<IActionResult> Update(int educationId)
        {
            var education = await educationService.GetEducationById(educationId);
            return View(education);
        }

        [HttpPost]
        public async Task<ActionResult> Update(EducationUpdateViewModel educationUpdateViewModel)
        {
            var map = mapper.Map<Education>(educationUpdateViewModel);
            var validationResult = await validator.ValidateAsync(map);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi", new ToastrOptions { Title = "Hata" });
                return View();
            }

            string educationTitle = await educationService.UpdateEducationAsync(educationUpdateViewModel);
            toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Education.Update(educationTitle), new ToastrOptions { Title = "Başarılı" });
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
