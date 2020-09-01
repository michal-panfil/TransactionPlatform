//using ServiceReference1;
using System;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionService.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
         /*   var client = new TransactionServiceClient();

            /*  var orderForm1 = new OrderForm()
              {
                  Ticker = "TST",
                  Price = 5.55f,
                  Volumen = 100,
                  UserId = "b8846332-7262-44b1-ba60-0b92552f0b3b",
                  TransactionTime = DateTime.Now,
                  OrderType = OrderType.Sell
              };
              var orderForm2 = new OrderForm()
              {
                  Ticker = "TST",
                  Price = 5.55f,
                  Volumen = 100,
                  UserId = "b8846332-7262-44b1-ba60-0b92552f0b3a",
                  TransactionTime = DateTime.Now,
                  OrderType = OrderType.Buy
              };*/


         /*  var orderForm1= new OrderForm("TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3a", DateTime.Now, OrderType.Buy);
            var orderForm2 = new OrderForm( "TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3b", DateTime.Now, OrderType.Sell);
            var x1 =   client.AcceptOrderAsync(orderForm1);
            var x2 =  client.AcceptOrderAsync(orderForm2);
            Console.WriteLine(await x1);
            Console.WriteLine( await x2);*/
        }
    }
}