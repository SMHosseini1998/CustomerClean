using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Domain.Models
{
    public class province /*: BaseEntity.BaseEntity */
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
       
        public string? name { get; set; }

        public virtual ICollection<city> citys { get; set; }
    }
}
