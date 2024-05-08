using Microsoft.AspNetCore.Identity;
using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class AppUser: IdentityUser<int>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Website { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Degree { get; set; }
        public string? Description { get; set; }
        public Image Image { get; set; }
        public int? ImageId { get; set; }
        public string? Title { get; set; }
        public string? Job { get; set; }
    }
}
