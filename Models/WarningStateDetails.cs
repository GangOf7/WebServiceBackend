using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class WarningStateDetails
    {

        [Key]
        public int Id { get; set; }
        public int Warning_ID { get; set; }
        [ForeignKey("Warning_ID")]
        public WarningMaster WarningMaster { get; set; }

        public int Param_Id { get; set; }
        [ForeignKey("Param_Id")]
        public Parameter_Master Parameter_Master { get; set; }

        public double Param_Greaterthan_val { get; set; }
        public double Param_LessThan_val { get; set; }
        public string lastupdatedby { get; set; }
        public DateTime lastupdatedon { get; set; }



    }
}
