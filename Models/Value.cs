using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace PiratesBay.Models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
    }
}
