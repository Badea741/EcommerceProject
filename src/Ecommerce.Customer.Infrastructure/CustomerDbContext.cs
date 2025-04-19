using Ecommerce.Base.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customer.Infrastructure;

public class CustomerDbContext(DbContextOptions<ApplicationDbContext> options) : ApplicationDbContext(options)
{
}