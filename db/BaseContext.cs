//using FalveyInsuranceGroup.backend.models;
using FalveyInsuranceGroup.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace FalveyInsuranceGroup.db
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        // Define DbSet properties for each model
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Policy> Policies { get; set; }

    }
}
