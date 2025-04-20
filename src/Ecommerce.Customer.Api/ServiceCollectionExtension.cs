using Ecommerce.Customer.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Customer.Api
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomerApi(this IServiceCollection services)
        {
            services.AddApplication();
            return services;
        }
    }
}
