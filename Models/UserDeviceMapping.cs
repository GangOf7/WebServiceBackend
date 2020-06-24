using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class UserDeviceMapping
    {
        [Key]
        public int Id { get; set; }

        public int Device_Id { get; set; }
        public int User_Id { get; set; }


    }
}
