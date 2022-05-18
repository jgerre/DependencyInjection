namespace DependencyInjection
{
    public class PaymentProcessor
    {
        public void ChargeCreditCard(string creditCardNumber, string expiryDate)
        {
            if(string.IsNullOrEmpty(creditCardNumber))
            {
                throw new ArgumentException("Invalid Credit Card");
            }
            if (string.IsNullOrEmpty(expiryDate))
            {
                throw new ArgumentException("Invalid Expiry Date");

            }

            Console.WriteLine("Call to Credit Card API");
        }
    }
}