using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Experience: EntityBase
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
    }
}
