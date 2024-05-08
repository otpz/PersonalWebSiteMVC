using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class TalentController : Controller
    {
        private readonly ITalentService talentService;
        private readonly IMapper mapper;
        private readonly IValidator<TalentAddViewModel> validator;
        private readonly IToastNotification toastNotification;

        public TalentController(ITalentService talentService, IMapper mapper, IValidator<TalentAddViewModel> validator, IToastNotification toastNotification)
        {
            this.talentService = talentService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult>Index()
        {
            var talents = await talentService.GetAllTalentsWithImageAsync();
            
            return View(talents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TalentAddViewModel talentAddViewModel)
        {
            var result = await validator.ValidateAsync(talentAddViewModel);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("İlgili alanları doldurunuz.", new ToastrOptions { Title = "Hata!"});
                return View();
            }
            
            string talentName = await talentService.CreateTalentAsync(talentAddViewModel);
            toastNotification.AddSuccessToastMessage(Messages.Talent.Add(talentName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Talent", new {Area = "Admin"});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int talentId)
        {
            string talentName = await talentService.SafeDeleteTalentAsync(talentId);
            toastNotification.AddSuccessToastMessage(Messages.Talent.Delete(talentName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Talent", new { Area = "Admin" });
        }


    }
}
