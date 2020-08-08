using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService.DAL;
using TransactionPlatform.TransactionService.Models;

namespace TransactionServTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOrderToDBTest()
        {
            var connector = new MongoConnector();
            var order = new Order()
            {
                IsValid = true,
                ReceivedDT = DateTime.Now,
               Status = OrderStatus.New,
               OrderForm = new OrderFormDto("TST", 12.2f, 1500, "134124134", DateTime.Now, OrderType.Buy)
            };

            connector.AddOrderToDb(order);

            var orderFromDB = connector.GetOrderFromDb(order.Id);
            Assert.IsNotNull(orderFromDB);
        }
    }
}
