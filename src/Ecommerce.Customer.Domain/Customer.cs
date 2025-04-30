using Ecommerce.Base.Domain;
using Ecommerce.Customer.Domain.Exceptions;

namespace Ecommerce.Customer.Domain;

public class Customer : Entity
{
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public Address? Address { get; private set; }
    public List<int> WishListProductIds { get; private set; } = new List<int>();
    public ICollection<PaymentInformation> PaymentInformation { get; private set; } = [];

    public Customer(int userId, string name)
    {
        UserId = userId;
        Name = string.IsNullOrWhiteSpace(name) ?
            throw new CustomerInvalidException("Name is required") :
            name;
    }

    public void AddToWishList(int productId)
    {
        if (!WishListProductIds.Contains(productId)) WishListProductIds.Add(productId);
    }

    public void RemoveFromWishList(int productId) =>
        WishListProductIds.Remove(productId);
}