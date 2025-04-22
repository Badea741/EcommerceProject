using Ecommerce.Base.Domain;
using Ecommerce.Customer.Domain.Exceptions;

namespace Ecommerce.Customer.Domain
{
    public class PaymentInformation : Entity
    {
        public PaymentMethod PaymentMethod { get; private set; }
        public string? CardNumber { get; private set; } // Store hash value
        public string? LastFourDigits { get; private set; }
        public int? ExpirationMonth { get; private set; }
        public int? ExpirationYear { get; private set; }
        public string? CardName { get; private set; }
        public string? CardHolderName { get; private set; }
        public string? Cvv { get; private set; }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; } = default!;

        public PaymentInformation(
            PaymentMethod paymentMethod,
            string? cardNumber = null,
            string? lastFourDigits = null,
            int? expirationMonth = null,
            int? expirationYear = null,
            string? cardName = null,
            string? cardHolderName = null,
            string? cvv = null)
        {
            if(!Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
                throw new PaymentInvalidException("Invalid payment method");

            if(IsCard(paymentMethod))
            {
                if (string.IsNullOrWhiteSpace(cardNumber))
                    throw new PaymentInvalidException("Card number is required");
                if (string.IsNullOrWhiteSpace(lastFourDigits) || LastFourDigits?.Length != 4)
                    throw new PaymentInvalidException("Last four digits must be 4 digits");
                if (string.IsNullOrWhiteSpace(cardName))
                    throw new PaymentInvalidException("Card name is required ");
                if (string.IsNullOrWhiteSpace(cardHolderName))
                    throw new PaymentInvalidException("Card holder name is required");
                if (expirationMonth is null || expirationMonth is < 1 or > 12)
                    throw new PaymentInvalidException("expiration month must be between 1 and 12");
                if (expirationYear is null || isFutureYear(expirationMonth.Value, expirationYear.Value))
                    throw new PaymentInvalidException("Invalid Year or Card is expired");
                if (string.IsNullOrWhiteSpace(cvv) || cvv?.Length != 3 || !cvv.All(Char.IsDigit))
                    throw new PaymentInvalidException("CVV must be 3 numeric digits");
            }
            

            PaymentMethod = paymentMethod;
            CardNumber = cardNumber;
            LastFourDigits = lastFourDigits;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            CardName = cardName;
            CardHolderName = cardHolderName;
            Cvv = cvv;
        }


        private bool IsCard(PaymentMethod paymentMethod) =>
            paymentMethod == PaymentMethod.CreditCard ||
            paymentMethod == PaymentMethod.DebitCard ||
            paymentMethod == PaymentMethod.PayPal;

        private bool isFutureYear(int expirationMonth,  int expirationYear) =>
            expirationYear > (DateTime.UtcNow.Year % 100) ||
            (expirationYear == (DateTime.UtcNow.Year % 100) && expirationMonth >= DateTime.UtcNow.Month);

    }
}
