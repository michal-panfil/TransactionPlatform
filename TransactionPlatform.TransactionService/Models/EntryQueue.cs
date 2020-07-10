using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class EntryQueue
    {
        public static List<TransactionOrder> TransactionQueue { get; } = new List<TransactionOrder>();

        public static bool AddToQueue(TransactionOrder transaction)
        {
            var isDuplicated = TransactionQueue.Any(i => i.Id == transaction.Id);

            if (!isDuplicated)
            {
                TransactionQueue.Add(transaction);
                return true;
            }
            return false;
        }
        public static bool RemoveFromQueue(TransactionOrder transaction)
        {
            var succesed =  TransactionQueue.Remove(transaction);
            return succesed;
        }

    }
}