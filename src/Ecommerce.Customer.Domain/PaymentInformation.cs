using Ecommerce.Base.Domain;
using Ecommerce.Customer.Domain.Exceptions;

namespace Ecommerce.Customer.Domain;

public class PaymentInformation : Entity
{
    public PaymentMethod PaymentMethod { get; private set; }
    public CardIdentification? CardIdentification { get; private set; }
    public CardExpiry? CardExpiry { get; private set; }
    public CardInformation? CardInformation { get; private set; }
    

    public PaymentInformation(
        PaymentMethod paymentMethod,
        CardIdentification? cardIdentification = null,
        CardExpiry? cardExpiry = null,
        CardInformation? cardInformation = null)
    {
        if (!Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
            throw new PaymentInvalidException("Invalid payment method");

        if (IsCard(paymentMethod))
        {
            if(cardInformation is null)
                throw new PaymentInvalidException("Card information is required");
            
            SetCardInformation(cardInformation);

            if (cardIdentification is null)
                throw new PaymentInvalidException("Card identification is required");

            SetCardIdentification(cardIdentification);

            if (cardExpiry is null)
                throw new PaymentInvalidException("Card expiry is required");

            SetCardExpirty(cardExpiry);

        }

        PaymentMethod = paymentMethod;
    }

    private void SetCardExpirty(CardExpiry cardExpiry)
    {
        if (cardExpiry.Month is < 1 or > 12)
            throw new PaymentInvalidException("expiration month must be between 1 and 12");
        if (cardExpiry.IsFutureYear())
            throw new PaymentInvalidException("Invalid Year or Card is expired");

        CardExpiry = cardExpiry;
    }

    private void SetCardIdentification(CardIdentification cardIdentification)
    {
        if (string.IsNullOrWhiteSpace(cardIdentification.CardNumber))
            throw new PaymentInvalidException("Card number is required");
        
        if (string.IsNullOrWhiteSpace(cardIdentification.LastFourDigits) ||
            cardIdentification.LastFourDigits?.Length != 4)
            throw new PaymentInvalidException("Last four digits must be 4 digits");

        if (string.IsNullOrWhiteSpace(cardIdentification.Cvv) || 
            cardIdentification.Cvv?.Length != 3 ||!cardIdentification.Cvv.All(Char.IsDigit))
            throw new PaymentInvalidException("CVV must be 3 numeric digits");

        CardIdentification = cardIdentification;
    }

    private void SetCardInformation(CardInformation cardInformation)
    {
        if (string.IsNullOrWhiteSpace(cardInformation.CardName))
            throw new PaymentInvalidException("Card name is required ");
        if (string.IsNullOrWhiteSpace(cardInformation.CardHolderName))
            throw new PaymentInvalidException("Card holder name is required");

        CardInformation = cardInformation;
    }

    private bool IsCard(PaymentMethod paymentMethod) =>
        paymentMethod == PaymentMethod.CreditCard ||
        paymentMethod == PaymentMethod.DebitCard ||
        paymentMethod == PaymentMethod.PayPal;
}