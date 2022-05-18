using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class OrderManager
    {
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            var productStockRepository = new ProductStockRepository();
            if (!productStockRepository.IsInStock(product))
                throw new Exception($"{product.ToString()} current not in stock");
            
            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

            var shippingProcessor = new ShippingProcessor();
            shippingProcessor.MailProduct(product);
        }
    }
}
