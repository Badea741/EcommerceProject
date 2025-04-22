using Ecommerce.Customer.Domain;
using Ecommerce.Customer.Infrastructure;

namespace Ecommerce.Customer.Persistence;

public class Repository(CustomerDbContext context) : IRepository
{
    public void Add(Domain.Customer customer) =>
        context.Add(customer);

    public void Delete(Domain.Customer customer) =>
        context.Remove(customer);

    public async Task<Domain.Customer?> Get(int id) =>
        await context.Customers.FindAsync(id);

    public void Update(Domain.Customer customer) =>
        context.Customers.Update(customer);
}
