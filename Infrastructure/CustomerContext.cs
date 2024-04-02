using CustomersCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace CustomersCrud.Infrastructure
{
    public class CustomerContext: DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        
        public DbSet<Customers> Customers { get; set; }
    }
}
