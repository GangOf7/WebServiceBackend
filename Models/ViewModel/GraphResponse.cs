using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.ViewModel
{
    public class GraphResponse
    {
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public int ParamID { get; set; }
        public string ParamName { get; set; }
        public List<ParamForGraph> ParameterValues { get; set; }

    }
}
