using FalveyInsuranceGroup.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FalveyInsuranceGroup.db
{
    // Allows us to interact with our database
    public class FalveyInsuranceGroupContext : DbContext
    {
        public FalveyInsuranceGroupContext(DbContextOptions<FalveyInsuranceGroupContext> options):base(options) 
        { 
        }
        
        // Override method from the base DbContext  class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(/* Entries can go here*/);
            modelBuilder.Entity<Employee>().HasData(/* Entries can go here*/);
            modelBuilder.Entity<Policy>().HasData(/*Entries can go here*/);
        }

        // Specify DbSet instance for operating with databases
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }       
        public DbSet<Policy> Policies { get; set; }
    }
}
