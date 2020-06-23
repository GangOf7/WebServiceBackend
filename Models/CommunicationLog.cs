using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class CommunicationLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataEntryTime { get; set; }

        public string PhoneNumber { get; set; }
        public string Message { get; set; }

    }
}
