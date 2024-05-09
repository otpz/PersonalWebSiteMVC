using Microsoft.AspNetCore.Http;

namespace PersonalWebSiteMVC.Entity.ViewModels.Portfolios
{
    public class PortfolioAddViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
