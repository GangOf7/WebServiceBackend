using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        public  string Name { get; set; }        
        public string PhoneNumber { get; set; }
        public string AlternativePhoneNumber { get; set; }

        public int Role_Id { get; set; }
        [ForeignKey("Role_Id")]
        public Role Role { get; set; }




    }
}
