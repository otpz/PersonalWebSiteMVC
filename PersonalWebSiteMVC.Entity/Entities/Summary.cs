using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Summary : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
