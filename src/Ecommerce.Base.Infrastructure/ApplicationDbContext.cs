using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Base.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}