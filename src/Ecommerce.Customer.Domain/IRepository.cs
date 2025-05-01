namespace Ecommerce.Customer.Domain;
public interface IRepository
{
    Task<Customer?> Get(int id);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(Customer customer);
}
