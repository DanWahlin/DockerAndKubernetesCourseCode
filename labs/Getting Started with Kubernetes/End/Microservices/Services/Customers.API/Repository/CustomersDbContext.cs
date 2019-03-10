using Microsoft.EntityFrameworkCore;
using Customers.API.Models;

namespace Customers.API.Repository
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CustomersDbContext (DbContextOptions<CustomersDbContext> options) : base(options) { }
    }
}