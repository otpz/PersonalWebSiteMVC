using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Talent : EntityBase
    {
        public Talent()
        {
            
        }

        public Talent(string name, int progress, int imageId)
        {
            Name = name;
            Progress = progress;
            ImageId = imageId;
        }

        public string Name { get; set; }
        public int Progress { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
