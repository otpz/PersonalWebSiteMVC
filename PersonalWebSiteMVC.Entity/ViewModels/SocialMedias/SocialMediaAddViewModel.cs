using Microsoft.AspNetCore.Http;

namespace PersonalWebSiteMVC.Entity.ViewModels.SocialMedias
{
    public class SocialMediaAddViewModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public IFormFile Photo { get; set; }
    }
}
