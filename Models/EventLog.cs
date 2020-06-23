using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class EventLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
        public DateTime DataEntryTime { get; set; }
        public string ErrorLocation { get; set; }


    }
}
