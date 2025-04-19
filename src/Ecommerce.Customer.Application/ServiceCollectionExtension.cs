using Ecommerce.Customer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Customer.Application;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();
        return services;
    }
}
