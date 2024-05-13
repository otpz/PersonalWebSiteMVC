using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly ISummaryService summaryService;
        public SummaryViewComponent(ISummaryService summaryService)
        {
            this.summaryService = summaryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var summary = await summaryService.GetFirstSummaryAsync();
            return View(summary);
        }
    }
}
