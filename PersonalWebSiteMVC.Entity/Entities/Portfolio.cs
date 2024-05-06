using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Portfolio: EntityBase
    {
        public string Description { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }
    }
}
