using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class CorrectiveMessage
    {
        [Key]
        public int Id { get; set; }
        public string MessageType { get; set; }
        public string Parameter { get; set; }
        public string Message { get; set; }




    }
}
