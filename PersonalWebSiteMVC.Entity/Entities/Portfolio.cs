using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Portfolio: EntityBase
    {
        public Portfolio()
        {
            
        }

        public Portfolio(string title, string description, Image image, int imageId)
        {
            Title = title;
            Description = description;
            Image = image;
            ImageId = imageId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public int? ImageId { get; set; }
    }
}
