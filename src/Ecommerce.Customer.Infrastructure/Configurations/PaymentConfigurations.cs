using Ecommerce.Customer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Customer.Infrastructure.Configurations
{
    public class PaymentConfigurations : IEntityTypeConfiguration<PaymentInformation>
    {
        public void Configure(EntityTypeBuilder<PaymentInformation> builder)
        {
            builder.Property(p => p.PaymentMethod)
                .HasConversion(method => method.ToString(),
                method => Enum.Parse<PaymentMethod>(method));
        }
    }
}
