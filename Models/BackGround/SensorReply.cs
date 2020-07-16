using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.BackGround
{
    public class SensorReply
    {
        public int deviceID { get; set; }
        public string NewGuid { get; set; }
        public double Interval { get; set; }
        public List<ParameterBenchmark> ThresHoldSets { get; set; }

    }
}
