using Ecommerce.Base.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce.Customer.Infrastructure;

public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : ApplicationDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Domain.Customer> Customers { get; set; }
    public DbSet<Domain.PaymentInformation> PaymentInformations { get; set; }
}