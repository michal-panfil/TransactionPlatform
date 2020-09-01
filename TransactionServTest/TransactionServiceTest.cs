using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService;
using TransactionPlatform.TransactionService.Models;

namespace TransactionServiceTest
{
    [TestFixture]
    public class TransactionServiceTest
    {
        // 1 accept order
        // 1.1 correct one
        // 1.2 bad one
        [Test, Explicit]
        public void AcceptOrderTest()
        {
            /*Pre-conditions:
            - one wallet with enough cash
            -one waller with enough instrument
            */
            var service = new TransactionService();
            var orderForm1 = new OrderForm("TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3a", DateTime.Now, OrderType.Buy);
            var orderForm2 = new OrderForm("TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3b", DateTime.Now, OrderType.Sell);

           var accepted1 = service.AcceptOrder(orderForm1);
            var accepted2 = service.AcceptOrder(orderForm2);
            
        }

        //2 get price of all instruments
        //2.1 test mode
        //2.2. productione mode based on last instrument transaction

        //3 Canncell order
        //3.1 correct operation
        //3.2 not existed operation
        //3.3 Done operation
  
        // 4 Authorisation
        // 4.1 authorized call
        // 4.2 un-authorized call

    }
}
