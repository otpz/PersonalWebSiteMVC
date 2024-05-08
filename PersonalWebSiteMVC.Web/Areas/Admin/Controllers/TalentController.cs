using AutoMapper;
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

        public TalentController(ITalentService talentService, IMapper mapper)
        {
            this.talentService = talentService;
            this.mapper = mapper;
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
            //var map = mapper.Map<Talent>(talentAddViewModel);
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
