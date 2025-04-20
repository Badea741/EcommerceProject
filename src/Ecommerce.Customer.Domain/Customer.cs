using Ecommerce.Base.Domain;

namespace Ecommerce.Customer.Domain;

public class Customer : Entity
{
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string? Address { get; private set; }
    public string? PaymentInformation { get; private set; }
    public List<int> WishListProductIds { get; private set; } = new List<int>();


    public Customer()
    {
        
    }
    public Customer(Guid id, int userId, string name)
    {
        Id = id;
        UserId = userId;
        Name = string.IsNullOrWhiteSpace(name) ?
            throw new ArgumentException("Name is required") :
            name;
    }

    public void SetPaymentInformation(string? paymentInformation) => 
        PaymentInformation = paymentInformation;

    public void AddToWishList(int productId)
    {
        if(!WishListProductIds.Contains(productId)) WishListProductIds.Add(productId);
    } 

    public void RemoveFromWishList(int productId) =>
        WishListProductIds.Remove(productId);
    
}