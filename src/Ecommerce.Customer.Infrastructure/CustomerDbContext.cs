using Ecommerce.Base.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customer.Infrastructure;

public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : ApplicationDbContext(options)
{
    public DbSet<Domain.Customer> Customers { get; set; }
}