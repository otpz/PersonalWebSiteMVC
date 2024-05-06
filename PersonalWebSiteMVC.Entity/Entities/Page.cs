using PersonalWebSiteMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Page : EntityBase
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
