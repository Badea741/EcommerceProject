using Ecommerce.Base.Domain;

namespace Ecommerce.Customer.Domain;
public class Address(string city, string zipCode, string country) : ValueObject
{
    public string? Street { get; private init; }
    public string City { get; private init; } = city;
    public string? State { get; private init; }
    public string ZipCode { get; private init; } = zipCode;
    public string Country { get; private init; } = country;
    public string? ApartmentNo { get; private init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return ZipCode;
        yield return Country;
        yield return ApartmentNo;
    }
}