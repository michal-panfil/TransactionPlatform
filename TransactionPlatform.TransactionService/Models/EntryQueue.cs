using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class EntryQueue
    {
        public static Queue<Order> TransactionQueue { get; } = new Queue<Order>();

        public static bool AddToQueue(Order transaction)
        {
            var isDuplicated = TransactionQueue.Any(i => i.Id == transaction.Id);

            if (!isDuplicated)
            {
                TransactionQueue.Enqueue(transaction);
                return true;
            }
            return false;
        }
        public static Order GetNextTransaction()
        {
            var nextTransaction =  TransactionQueue.Dequeue();
            return nextTransaction;
        }

    }
}