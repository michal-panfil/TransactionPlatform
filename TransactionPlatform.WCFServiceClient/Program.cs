using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionPlatform.TransactionService;

namespace TransactionPlatform.WCFServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.Service1Client();
            var result = client.GetPriceOfInstrument(1000);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
