﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesBay.Models
{
    public class ParameterBenchmark
    {
        [Key]
        public int Id { get; set; }
        public int Param_Id { get; set; }
        [ForeignKey("Param_Id")]
        public  Parameter_Master Parameter_Master { get; set; }
        [Required]
        public double Green_Threshold_High { get; set; }
        [Required]
        public double Green_Threshold_Low { get; set; }
        [Required]
        public double Amber_Threshold_High { get; set; }
        [Required]
        public double Amber_Threshold_Low { get; set; }
        [Required]
        public double Red_Threshold_High { get; set; }
        [Required]
        public double Red_Threshold_Low { get; set; }
        
        public string lastupdatedby { get; set; }
        public DateTime lastupdatedon { get; set; }


    }
}
