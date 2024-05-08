using PersonalWebSiteMVC.Entity.Entities;

namespace PersonalWebSiteMVC.Entity.ViewModels.Talents
{
    public class TalentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Progress { get; set; }
        public Image Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
