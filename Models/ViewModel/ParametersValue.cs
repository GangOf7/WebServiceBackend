using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models.ViewModel
{
    public class ParametersValue
    {
        public string Name { get; set; }
        public double LastValue { get; set; }
        public DateTime InputTime { get; set; }
        public string Color { get; set; }
        public bool Action { get; set; }
        public string correctiveAction { get; set; }
        public string Unit { get; set; }

    }
}
