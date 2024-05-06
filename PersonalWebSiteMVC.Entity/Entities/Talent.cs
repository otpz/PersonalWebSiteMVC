using PersonalWebSiteMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Talent : EntityBase
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }


        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
