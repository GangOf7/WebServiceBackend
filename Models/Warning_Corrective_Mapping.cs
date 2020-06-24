using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class Warning_Corrective_Mapping
    {
        [Key]
        public int Id { get; set; }

        public int CorrectiveMessage_ID { get; set; }
        public int Warning_ID { get; set; }


        public string lastupdatedby { get; set; }
        public DateTime lastupdatedon { get; set; }

    }
}
