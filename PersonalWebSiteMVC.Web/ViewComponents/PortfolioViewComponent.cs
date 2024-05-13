using Microsoft.AspNetCore.Mvc;
using PersonalWebSiteMVC.Service.Services.Abstractions;

namespace PersonalWebSiteMVC.Web.ViewComponents
{
    public class PortfolioViewComponent : ViewComponent
    {
        private readonly IPortfolioService portfolioService;

        public PortfolioViewComponent(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var portfolios = await portfolioService.GetAllPortfolioWithImageAsync();
            return View(portfolios);
        }
    }
}
