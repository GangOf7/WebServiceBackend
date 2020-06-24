using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class WarningMaster
    {
        [Key]
        public int Id { get; set; }

        public  string Warning_message { get; set; }
        public string lastupdatedby { get; set; }
        public DateTime lastupdatedon { get; set; }


    }
}
