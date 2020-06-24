using System;
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

        public DbSet<Value> Values {get; set;}
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
                    new Value { Id=1,Name="Value 100"},
                    new Value { Id=3,Name="Value 106"},
                    new Value { Id=5,Name="Value 102"}
                );
        }
    }
}
