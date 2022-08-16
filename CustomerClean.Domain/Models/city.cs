using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Domain.Models
{
    public class city /*: BaseEntity.BaseEntity*/
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
       
        public int province_id { get; set; }
        public int county_id { get; set; }
        public string? name { get; set; }

         [ForeignKey("province_id")]
        public virtual province Province { get; set; }
    }
}
