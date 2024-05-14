using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Educations;
using PersonalWebSiteMVC.Entity.ViewModels.Experiences;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Service.Services.Concretes;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService experienceService;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<Experience> validator;
        private readonly IMapper mapper;

        public ExperienceController(IExperienceService experienceService, IToastNotification toastNotification, IValidator<Experience> validator, IMapper mapper)
        {
            this.experienceService = experienceService;
            this.toastNotification = toastNotification;
            this.validator = validator;
            this.mapper = mapper;
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
            var map = mapper.Map<Experience>(experienceAddViewModel);
            var validatorResult = await validator.ValidateAsync(map);
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
        public async Task<IActionResult> Update(int experienceId)
        {
            var experience = await experienceService.GetExperienceById(experienceId);
            return View(experience);
        }

        [HttpPost]
        public async Task<ActionResult> Update(ExperienceUpdateViewModel experienceUpdateViewModel)
        {
            var map = mapper.Map<Experience>(experienceUpdateViewModel);
            var validationResult = await validator.ValidateAsync(map);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi", new ToastrOptions { Title = "Hata" });
                return View();
            }

            string experienceTitle = await experienceService.UpdateExperienceAsync(experienceUpdateViewModel);
            toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Education.Update(experienceTitle), new ToastrOptions { Title = "Başarılı" });
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
