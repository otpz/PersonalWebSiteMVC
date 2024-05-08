using Microsoft.AspNetCore.Http;

namespace PersonalWebSiteMVC.Entity.ViewModels.Talents
{
    public class TalentAddViewModel
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public IFormFile Photo { get; set; }
    }
}
