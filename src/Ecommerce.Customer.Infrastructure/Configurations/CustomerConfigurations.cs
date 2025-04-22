using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Customer.Infrastructure.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Domain.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Customer> builder)
        {
            builder.OwnsOne(c => c.Address);

            builder.HasOne(c => c.PaymentInformation)
                .WithOne(p => p.Customer)
                .HasForeignKey<Domain.PaymentInformation>(p => p.CustomerId)
                .IsRequired(false);
        }
    }
}
