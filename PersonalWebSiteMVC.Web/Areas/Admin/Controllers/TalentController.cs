using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Entity.ViewModels.Talents;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class TalentController : Controller
    {
        private readonly ITalentService talentService;
        private readonly IMapper mapper;
        private readonly IValidator<TalentAddViewModel> validator;

        public TalentController(ITalentService talentService, IMapper mapper, IValidator<TalentAddViewModel> validator)
        {
            this.talentService = talentService;
            this.mapper = mapper;
            this.validator = validator;
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
                return View();
            }

            await talentService.CreateTalentAsync(talentAddViewModel);
            return RedirectToAction("Index", "Talent", new {Area = "Admin"});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int talentId)
        {
            string talentName = await talentService.SafeDeleteTalentAsync(talentId);

            return RedirectToAction("Index", "Talent", new { Area = "Admin" });
        }


    }
}
