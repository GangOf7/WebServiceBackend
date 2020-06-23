using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class ParameterMeasureMarkRed
    {
        [Key]
        public int Id { get; set; }
        public double Dissolved_oxygen_High { get; set; }
        public double Total_Dissolved_Solid_High { get; set; }
        public double Salinity_High { get; set; }
        public double Water_Temperature_High { get; set; }
        public double PH_Level_High { get; set; }
        public double Ammonium_level_High { get; set; }
        public double Dissolved_oxygen_Low { get; set; }
        public double Total_Dissolved_Solid_Low { get; set; }
        public double Salinity_Low { get; set; }
        public double Water_Temperature_Low { get; set; }
        public double PH_Level_Low { get; set; }
        public double Ammonium_level_Low { get; set; }


    }
}
