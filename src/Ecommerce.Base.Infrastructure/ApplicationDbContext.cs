using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Base.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}