namespace Ecommerce.Customer.Domain;
public interface IRepository
{
    Task<Customer?> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    void AddAsync(Customer customer);
    void UpdateAsync(Customer customer);
    void DeleteAsync(Customer customer);
}
