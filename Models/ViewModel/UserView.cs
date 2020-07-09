using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.ViewModel
{
    public class UserView
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int DeviceCount { get; set; }
        public string EmailID { get; set; }

        public List<DeviceDetails> DeviceDetail { get; set; }
    }
}   
