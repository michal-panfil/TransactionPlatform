using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService.DAL;
using TransactionPlatform.TransactionService.Models;
using Xunit;

namespace TransactionServiceTest.DAL
{
    public class MongoCOnectorTest
    {
        [Fact]
        public void AddOrderToDBTest()
        {
            MongoContext connector = new MongoContext();
            var order = new Order();
            order.Id = new Guid("07c811a3-0307-5948-9f53-e261f90616cb");
            connector.MoveOrder(new List<Order>() { order });

          //  connector.AddOrderToDb(order); 

        }
    }
}
