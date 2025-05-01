using Ecommerce.Base.Domain;

namespace Ecommerce.Customer.Domain;
public class CardIdentification(string cardNumber, string lastFourDigits, string cvv) : ValueObject
{
    public string CardNumber { get; private init; } = cardNumber; // Store hash value
    public string LastFourDigits { get; private init; } = lastFourDigits;
    public string Cvv { get; private init; } = cvv;


    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CardNumber;
        yield return LastFourDigits;
        yield return Cvv;
    }
}
