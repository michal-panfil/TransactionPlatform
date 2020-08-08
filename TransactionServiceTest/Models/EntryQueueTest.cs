using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.TransactionService.Models;

namespace TransactionServiceTest.Models
{
    [TestFixture]
    public class EntryQueueTest
    {
        [Test]
        public void AddToQueueTest()
        {
            var order = new Order();

            bool sucessfullAdded = EntryQueue.AddToQueue(order);
            
            Assert.IsTrue(sucessfullAdded);
            Assert.IsTrue(EntryQueue.TransactionQueue.Contains(order));
        }
        [Test]
        public void AddToQueueTest_Duplicated()
        {
            var order = new Order();

            var sucessfullAdded = EntryQueue.AddToQueue(order);
            sucessfullAdded = EntryQueue.AddToQueue(order);

            Assert.IsFalse(sucessfullAdded);
            Assert.IsTrue(EntryQueue.TransactionQueue.Count == 1);
        }
        [Test]
        public void GetNextTransactionTest()
        {
            var order = new Order();
            var orderTwo = new Order();
            var sucessfullAdded1 = EntryQueue.AddToQueue(order);
            var sucessfullAdded2 = EntryQueue.AddToQueue(orderTwo);
            if (EntryQueue.TransactionQueue.Count == 0) Assert.Fail("Something went wrong woth adding ordet to list"); 

            var orderFromQueue = EntryQueue.GetNextTransaction();

            Assert.IsTrue(order.Id == orderFromQueue.Id);
            Assert.IsTrue(EntryQueue.TransactionQueue.Count == 1);
        }
    }
}
