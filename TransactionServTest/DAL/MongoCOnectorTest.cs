using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService.Models;
using Xunit;

namespace TransactionServiceTest.DAL
{
    public class MongoCOnectorTest
    {
        [Fact]
        public void AddOrderToDBTest()
        {
           /* MongoContext connector = new MongoContext();
            var order = new Order()
            {
               IsValid = true,
                ReceivedDT = DateTime.Now,
                Status = OrderStatus.New,
               OrderForm = new OrderForm("TST", 12.2f, 1500, "134124134", DateTime.Now, OrderType.Buy)
            };

            connector.AddOrderToDb(order); */

        }
    }
}
