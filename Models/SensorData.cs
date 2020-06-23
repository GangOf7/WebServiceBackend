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

        public DateTime DataEntryTime { get; set; }
        public double Dissolved_oxygen { get;set; }
        public double Total_Dissolved_Solid { get; set; }
        public double Salinity { get; set; }
        public double Water_Temperature { get; set; }
        public double PH_Level { get; set; }
        public double Ammonium_level { get; set; }
    }
}
