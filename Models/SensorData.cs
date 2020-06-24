using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class SensorData
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public int Device_Id { get; set; }
        [ForeignKey("Device_Id")]
        public Device_info Device_Info { get; set; }
        public int Param_Id { get; set; }
        [ForeignKey("Param_Id")]
        public  Parameter_Master  Parameter_Master { get; set; }        
        public double Input_Value { get;set; }
        public DateTime DataEntryTime { get; set; }

    }
}
