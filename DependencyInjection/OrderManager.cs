using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public interface IOrderManager
    {
        void Submit(Product product, string creditCardNumber, string expiryDate);
    }
    public class OrderManager : IOrderManager
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IShippingProcessor _shippingProcessor;

        public OrderManager(IProductStockRepository productStockRepository, IPaymentProcessor paymentProcessor, IShippingProcessor shippingProcessor)
        {
            _productStockRepository = productStockRepository;
            _paymentProcessor = paymentProcessor;
            _shippingProcessor = shippingProcessor;
        }
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {

            if (!_productStockRepository.IsInStock(product))
                throw new Exception($"{product.ToString()} current not in stock");
            
            _paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

            _shippingProcessor.MailProduct(product);
        }
    }
}
