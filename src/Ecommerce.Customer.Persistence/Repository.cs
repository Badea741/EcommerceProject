using Ecommerce.Customer.Domain;
using Ecommerce.Customer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customer.Persistence;

public class Repository(CustomerDbContext _context) : IRepository
{
    public void AddAsync(Domain.Customer customer) =>
        _context.Add(customer);

    public void DeleteAsync(Domain.Customer customer) =>
        _context.Remove(customer);

    public async Task<IEnumerable<Domain.Customer>> GetAllAsync() =>
        await _context.Customers.ToListAsync();

    public async Task<Domain.Customer?> GetByIdAsync(int id) =>
        await _context.Customers.FindAsync(id);

    public void UpdateAsync(Domain.Customer customer) =>
        _context.Customers.Update(customer);
}
