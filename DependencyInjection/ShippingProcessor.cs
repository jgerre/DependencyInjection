namespace DependencyInjection
{
    public class ShippingProcessor
    {
        internal void MailProduct(Product product)
        {
            var productStockRepository = new ProductStockRepository();
            productStockRepository.ReduceStock(product);
            Console.WriteLine("Call to shipping API");
        }
    }
}