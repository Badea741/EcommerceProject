using Ecommerce.Base.Domain.Exceptions;

namespace Ecommerce.Customer.Domain.Exceptions;

public class CustomerInvalidException : ValidationException
{
    public CustomerInvalidException(string message)
        : base(message)
    {
    }
}