using Ecommerce.Base.Domain;

namespace Ecommerce.Customer.Domain;

public class CardExpiry(int month, int year) : ValueObject
{
    public int Month { get; private init; } = month;
    public int Year { get; private init; } = year;

    public bool IsFutureYear() =>
       Year > (DateTime.UtcNow.Year % 100) ||
       (Year == (DateTime.UtcNow.Year % 100) && Month >= DateTime.UtcNow.Month);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Month;
        yield return Year;
    }
}