using PersonalWebSiteMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class SocialMedia: EntityBase
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
