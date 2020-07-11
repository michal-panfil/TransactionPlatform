using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class EntryQueue
    {
        public static Queue<TransactionOrder> TransactionQueue { get; } = new Queue<TransactionOrder>();

        public static bool AddToQueue(TransactionOrder transaction)
        {
            var isDuplicated = TransactionQueue.Any(i => i.Id == transaction.Id);

            if (!isDuplicated)
            {
                TransactionQueue.Enqueue(transaction);
                return true;
            }
            return false;
        }
        public static TransactionOrder GetNextTransaction ()
        {
            var nextTransaction =  TransactionQueue.Dequeue();
            return nextTransaction;
        }

    }
}