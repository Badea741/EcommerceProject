using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Customer.Infrastructure.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Domain.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Customer> builder)
        {
            builder.OwnsOne(c => c.Address);
            builder.HasMany(x => x.PaymentInformation);
        }
    }
}