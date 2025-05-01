namespace Ecommerce.Base.Domain.Exceptions;

public abstract class ValidationException(string message) : Exception(message)
{
}