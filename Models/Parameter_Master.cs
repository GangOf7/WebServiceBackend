using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class Parameter_Master
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Param_Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Status { get; set; }
        public string lastupdatedby { get; set; }
        public DateTime lastupdatedon { get; set; }
        public string Unit { get; set; }
    }
}
