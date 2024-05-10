using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Entity.ViewModels.SocialMedias
{
    public class SocialMediaViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
