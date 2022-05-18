/* Tutorial Dependency Injection
 * https://www.youtube.com/watch?v=2rv-lcqW1tM 
 */
namespace DependencyInjection

{
    class Program
    {
        static void Main(string[] args)
        {
            var product = string.Empty;
            var orderManager = new OrderManager();
            while (product != "exit")
            {
                Console.WriteLine(@" Enter a ProductProduct: 
Keyboard = 0,
Mouse = 1,
Mic = 2,
Speaker = 3");

                product = Console.ReadLine();
                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("enter a valid payment method: XXXXXXXXXXXXXXXX;MMYY");
                        var paymentMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)
                            throw new Exception("lnvalid Payment Method");
                        orderManager.Submit(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has been shipped");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}