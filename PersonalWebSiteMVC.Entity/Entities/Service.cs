using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Service: EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }

    }
}
