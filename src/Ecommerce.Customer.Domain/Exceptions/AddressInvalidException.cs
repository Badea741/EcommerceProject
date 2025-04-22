using Ecommerce.Base.Domain.Exceptions;

namespace Ecommerce.Customer.Domain.Exceptions
{
    public class AddressInvalidException(string message) : ValidationException(message)
    {
    }
}
