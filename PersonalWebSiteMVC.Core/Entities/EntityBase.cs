using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWebSiteMVC.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? DeletedDate { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
