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
            var order = new TransactionOrder();

            bool sucessfullAdded = EntryQueue.AddToQueue(order);
            
            Assert.IsTrue(sucessfullAdded);
            Assert.IsTrue(EntryQueue.TransactionQueue.Contains(order));
        }
        [Test]
        public void AddToQueueTest_Duplicated()
        {
            var order = new TransactionOrder();

            var sucessfullAdded = EntryQueue.AddToQueue(order);
            sucessfullAdded = EntryQueue.AddToQueue(order);

            Assert.IsFalse(sucessfullAdded);
            Assert.IsTrue(EntryQueue.TransactionQueue.Count == 1);
        }
        [Test]
        public void RemoveFromQueueTest()
        {
            var order = new TransactionOrder();
            var sucessfullAdded = EntryQueue.AddToQueue(order);
            if (EntryQueue.TransactionQueue.Count == 0) Assert.Fail(); //Something went wrong woth adding ordet to list

            var removedSuccesed = EntryQueue.RemoveFromQueue(order);

            Assert.IsTrue(removedSuccesed);
            Assert.IsTrue(EntryQueue.TransactionQueue.Count == 0);
        }
        [Test]
        public void RemoveFromQueueTest_DosntExistIterm()
        {
            var order = new TransactionOrder();
          
            var removedSuccesed = EntryQueue.RemoveFromQueue(order);

            Assert.IsFalse(removedSuccesed);
        }
    }
}
