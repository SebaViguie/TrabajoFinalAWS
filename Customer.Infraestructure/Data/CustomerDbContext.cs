using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infraestructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}