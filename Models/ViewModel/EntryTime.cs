using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.ViewModel
{
    public class EntryTime
    {
        public DateTime datetime { get; set; }
        public List<ParamsForDevice> Params { get; set; }
    }
}
