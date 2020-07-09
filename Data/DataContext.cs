﻿using System;
using Microsoft.EntityFrameworkCore;
using PiratesBay.Models;

namespace PiratesBay.Data
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions options;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.options = options;

        }

        public DbSet<Value> Values { get; set; }
        public DbSet<CommunicationLog> CommunicationLog { get; set; }
        public DbSet<CorrectiveMessage> CorrectiveMessage { get; set; }
        public DbSet<Device_info> Device_info { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Parameter_Master> Parameter_Masters { get; set; }
        public DbSet<ParameterBenchmark> ParameterBenchmark { get; set; }
        public DbSet<UserDeviceMapping> UserDeviceMapping { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                    new Value { Id = 1, Name = "Value 100" },
                    new Value { Id = 3, Name = "Value 106" },
                    new Value { Id = 5, Name = "Value 102" }
                    );

            builder.Entity<Role>()
                .HasData(
                    new Role { Id = 1, RoleName = "Administrator" },
                    new Role { Id = 2, RoleName = "General User" },
                    new Role { Id = 3, RoleName = "Owner" },
                    new Role { Id = 4, RoleName = "Care Taker" }
                    );

            builder.Entity<UserInfo>()
                .HasData(
                    new UserInfo { Id = 1, Name = "Will Turner", Role_Id = 1 },
                    new UserInfo { Id = 2, Name = "Elizabeth Swann", Role_Id = 2 }
                    );

            builder.Entity<Device_info>()
                .HasData(
                    new Device_info { Id = 1, Device_Name = "HMS Interceptor", Area = "Sundarban", Country = "India", State = "West Bengal", GUID = new Guid().ToString(), Status = true },
                    new Device_info { Id = 2, Device_Name = "The Queen Anne's Revenge", Area = "Bantala", Country = "India", State = "West Bengal", GUID = new Guid().ToString(), Status = true },
                    new Device_info { Id = 3, Device_Name = "The Silent Mary", Area = "Kolkata", Country = "India", State = "West Bengal", GUID = new Guid().ToString(), Status = true },
                    new Device_info { Id = 4, Device_Name = "Empress", Area = "Hoogly", Country = "India", State = "West Bengal", GUID = new Guid().ToString(), Status = true },
                    new Device_info { Id = 5, Device_Name = "Lord Beckett's Armada", Area = "Midnapore", Country = "India", State = "West Bengal", GUID = new Guid().ToString(), Status = true }
                    );

            builder.Entity<UserDeviceMapping>()
                .HasData(
                    new UserDeviceMapping { Id = 1, Device_Id = 1, User_Id = 1 },
                    new UserDeviceMapping { Id = 2, Device_Id = 2, User_Id = 1 },
                    new UserDeviceMapping { Id = 3, Device_Id = 3, User_Id = 1 },
                    new UserDeviceMapping { Id = 4, Device_Id = 4, User_Id = 1 },
                    new UserDeviceMapping { Id = 5, Device_Id = 5, User_Id = 1 }
                    );

            builder.Entity<Parameter_Master>()
                .HasData(
                new Parameter_Master { Id = 1, Param_Name = "Temperature" },
                new Parameter_Master { Id = 2, Param_Name = "PH Level" },
                new Parameter_Master { Id = 3, Param_Name = "Partical Level" },
                new Parameter_Master { Id = 4, Param_Name = "Oxygen Level" },
                new Parameter_Master { Id = 5, Param_Name = "Salinity" }
                );

        }




        public DbSet<PiratesBay.Models.Warning_Corrective_Mapping> Warning_Corrective_Mapping { get; set; }




        public DbSet<PiratesBay.Models.WarningMaster> WarningMaster { get; set; }




        public DbSet<PiratesBay.Models.WarningStateDetails> WarningStateDetails { get; set; }
    }
}
