using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.ViewModel
{
    public class DeviceWiseData
    {
        public int Device_Id { get; set; }
        public string Device_Name { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Status { get; set; }
        public DateTime lastupdatedon { get; set; }
        public List<string> ParameterNames { get; set; }

        public List<EntryTime> Entries { get; set; }

    }
}
