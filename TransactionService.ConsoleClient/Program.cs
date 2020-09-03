//using ServiceReference1;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionService.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TransactionServiceClient();

         

           var orderForm1= new OrderForm("TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3a", DateTime.Now, OrderType.Buy);
            var orderForm2 = new OrderForm( "TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3b", DateTime.Now, OrderType.Sell);
            try
            {
                var x1 = client.AcceptOrderAsync(orderForm1).Result;
                var x2 = client.AcceptOrderAsync(orderForm2).Result;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            
        }
    }
}