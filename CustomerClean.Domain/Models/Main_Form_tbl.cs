using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Domain.Models
{
    public class Main_Form_tbl : BaseEntity.BaseEntity
    {
        public string? FName { get; set; }
        public string? Lname { get; set; }
        public string? Sys_Id { get; set; }
        public string? Mobile { get; set; }
        public int State_Id { get; set; }
        public int City_Id { get; set; }
        public string? Address { get; set; }
        public int Services_Id { get; set; }
        public string? Gride_id { get; set; }
        public string? Meli_Image_Name { get; set; }
        public string? Guarantee_Image_Name { get; set; }

        [ForeignKey("City_Id")]
        public virtual city city { get; set; }

   

        [ForeignKey("Services_Id")]
        public virtual Services_tbl Services_tbl { get; set; }
    }
}
