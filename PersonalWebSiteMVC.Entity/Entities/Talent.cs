using PersonalWebSiteMVC.Core.Entities;
namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Talent : EntityBase
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
