using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalWebSiteMVC.Entity.Entities;
using PersonalWebSiteMVC.Service.Services.Abstractions;
using PersonalWebSiteMVC.Web.ResultMessages;

namespace PersonalWebSiteMVC.Web.Areas.Admin.Controllers
{

    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class SummaryController : Controller
    {
        private readonly ISummaryService summaryService;
        private readonly IValidator<Summary> validator;
        private readonly IToastNotification toastNotification;

        public SummaryController(ISummaryService summaryService, IValidator<Summary> validator, IToastNotification toastNotification)
        {
            this.summaryService = summaryService;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var summary = await summaryService.GetFirstSummaryAsync();
            return View(summary);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Summary summary)
        {
            var result = await validator.ValidateAsync(summary);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage("Validasyon hatası", new ToastrOptions { Title = "Başarısız"});
                return View();
            }

            string summaryTitle = await summaryService.UpdateSummaryAsync(summary);

            toastNotification.AddSuccessToastMessage(Messages.Summary.Update(summaryTitle), new ToastrOptions { Title = "Başarılı" });

            return View();
        }
    }
}
