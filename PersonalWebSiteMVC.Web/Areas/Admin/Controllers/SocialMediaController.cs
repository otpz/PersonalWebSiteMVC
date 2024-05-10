using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.SocialMedias;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<SocialMediaAddViewModel> validator;

        public SocialMediaController(ISocialMediaService socialMediaService, IToastNotification toastNotification, IValidator<SocialMediaAddViewModel> validator)
        {
            this.socialMediaService = socialMediaService;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var socialMedias = await socialMediaService.GetAllSocialMediasWithImageAsync();
            return View(socialMedias);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SocialMediaAddViewModel socialMediaAddViewModel)
        {
            var validationResult = await validator.ValidateAsync(socialMediaAddViewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası meydana geldi.", new ToastrOptions { Title = "Hata" });
                return View();
            }

            string socialMediaTitle = await socialMediaService.CreateSocialMediaAsync(socialMediaAddViewModel);
            toastNotification.AddSuccessToastMessage(Messages.SocialMedia.Add(socialMediaTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "SocialMedia", new {Area="Admin"});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int socialMediaId)
        {
            string socialMediaTitle = await socialMediaService.SafeDeleteSocialMediaAsync(socialMediaId);
            toastNotification.AddSuccessToastMessage(Messages.SocialMedia.Delete(socialMediaTitle), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
        }

        


    }
}
