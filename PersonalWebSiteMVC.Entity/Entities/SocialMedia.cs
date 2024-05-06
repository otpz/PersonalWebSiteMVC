using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class SocialMedia: EntityBase
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }

    }
}
