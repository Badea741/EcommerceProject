namespace Ecommerce.Base.Domain.Exceptions
{
    public abstract class ValidationException : Exception
    {
        public ValidationException(string message) :base(message)
        { }
    }
}
