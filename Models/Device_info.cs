using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class Device_info
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string GUID { get; set; }
        public string Mac_Id { get; set; }
        [Required]
        public string Device_Name { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Status { get; set; }



    }
}
