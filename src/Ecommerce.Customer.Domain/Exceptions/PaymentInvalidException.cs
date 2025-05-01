using Ecommerce.Base.Domain.Exceptions;

namespace Ecommerce.Customer.Domain.Exceptions;

public class PaymentInvalidException(string message) : ValidationException(message)
{
}