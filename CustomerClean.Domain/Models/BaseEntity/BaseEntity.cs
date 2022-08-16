using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Domain.Models.BaseEntity;
public abstract class BaseEntity : TBaseEntity<int>
{
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public DateTime? CreateDate { get; set; } = DateTime.Now;
    public DateTime? LastUpdate { get; set; } = DateTime.Now;
    //public virtual int? ModifierId { get; set; }

    //[ForeignKey("ModifierId")]
    //public virtual User ModifierUser { get; set; }
}