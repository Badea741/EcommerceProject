using Ecommerce.Base.Domain;
using Ecommerce.Customer.Domain.Exceptions;

namespace Ecommerce.Customer.Domain;

public class Address : ValueObject
{
    public string? Street { get; private init; }
    public string City { get; private init; }
    public string? State { get; private init; }
    public string ZipCode { get; private init; }
    public string Country { get; private init; }
    public string? ApartmentNo { get; private init; }

    public Address(string city, string zipCode, string country,
        string? street = null, string? state = null, string? apartmentNo = null)
    {
        City = string.IsNullOrWhiteSpace(city) ?
            throw new AddressInvalidException("City is required") :
            city;
        ZipCode = string.IsNullOrEmpty(zipCode) ?
            throw new AddressInvalidException("ZipCode is required") :
            zipCode;
        Country = string.IsNullOrEmpty(country) ?
            throw new AddressInvalidException("Country is required") :
            country;

        Street = street;
        State = state;
        ApartmentNo = apartmentNo;
    }

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