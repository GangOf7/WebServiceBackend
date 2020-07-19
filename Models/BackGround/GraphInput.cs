using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.BackGround
{
    public class GraphInput
    {
        public int DeviceID { get; set; }
        public int ParameterID { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
