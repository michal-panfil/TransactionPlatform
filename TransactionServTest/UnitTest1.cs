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
            var connector = new MongoContext();
            var order = new Order()
            {
                IsValid = true,
                ReceivedDT = DateTime.Now,
               Status = OrderStatus.New,
               OrderForm = new OrderFormDto("TST", 12.2f, 1500, "134124134", DateTime.Now, OrderType.Buy)
            };

            connector.AddOrderToDb(order);

            var orderFromDB = connector.GetOrderFromDb(order.Id);
            Assert.IsTrue(orderFromDB.Id ==  order.Id);
        }

        /*
        [TestMethod]
        public void ChangeStatusTest()
        {
            var connector = new MongoContext();

            var result = connector.ChangeStatus(new Guid("3a4800f7-9e9f-4ba7-8437-f00d3e3f0b6a"), OrderStatus.Accepted);
            Assert.IsTrue(result == 1);

        }*/
        //3a4800f7-9e9f-4ba7-8437-f00d3e3f0b6a
    }
}
