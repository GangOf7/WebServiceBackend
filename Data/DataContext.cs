using System;
using Microsoft.EntityFrameworkCore;
using PiratesBay.Models;

namespace PiratesBay.Data
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions options;
        public DataContext(DbContextOptions options) : base(options)
        {
            this.options = options;

        }

        public DbSet<Value> Values {get; set;}


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
