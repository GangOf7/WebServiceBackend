using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class CommunicationLog
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public UserInfo UserInfo { get; set; }

        public int warning_corrective_mapping_ID { get; set; }
        [ForeignKey("warning_corrective_mapping_ID")]
        public Warning_Corrective_Mapping Warning_Corrective_Mapping { get; set; }

        public string Message { get; set; }
        public string Communication_Type { get; set; }        

        public DateTime DataEntryTime { get; set; }
        
        



    }
}
