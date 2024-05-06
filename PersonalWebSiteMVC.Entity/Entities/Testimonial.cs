using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Testimonial: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public string Message { get; set; }
    }
}
