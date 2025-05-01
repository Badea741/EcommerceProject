using Ecommerce.Base.Domain;

namespace Ecommerce.Customer.Domain;
public class CardInformation(string cardName, string cardHolderName) : ValueObject
{
    public string CardName { get; private init; } = cardName;
    public string CardHolderName { get; private init; } = cardHolderName;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CardName;
        yield return CardHolderName;
    }
}
