using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.ViewModel
{
    public class DeviceDetails
    {
        public int Id { get; set; }
        public string Device_Name { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public DateTime lastupdatedon { get; set; }
        public string Color { get; set; }

        public List<ParametersValue> ParameterValues { get; set; }

        public static implicit operator List<object>(DeviceDetails v)
        {
            throw new NotImplementedException();
        }
    }
}
