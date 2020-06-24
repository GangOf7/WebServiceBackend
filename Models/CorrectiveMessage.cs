using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class CorrectiveMessage
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        public string Green_Threshold_High { get; set; }
        [Required]
        public string Green_Threshold_Low { get; set; }
        [Required]
        public string Amber_Threshold_High { get; set; }
        [Required]
        public string Amber_Threshold_Low { get; set; }
        [Required]
        public string Red_Threshold_High { get; set; }
        [Required]
        public string Red_Threshold_Low { get; set; }

        public string MessageType { get; set; }
        public string lastupdatedby { get; set; }
        public DateTime lastupdatedon { get; set; }





    }
}
