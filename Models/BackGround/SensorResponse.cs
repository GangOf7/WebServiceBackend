using PiratesBay.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.BackGround
{
    public class SensorResponse
    {
        public int DeviceId { get; set; }
        public string Guid { get; set; }
        public string MacID { get; set; }
        public DateTime dateTime { get; set; }

        public List<SensorSet> DataSet { get; set; }
    }
}
