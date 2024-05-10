using Microsoft.AspNetCore.Http;
using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Entity.ViewModels.Portfolios
{
    public class PortfolioUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
