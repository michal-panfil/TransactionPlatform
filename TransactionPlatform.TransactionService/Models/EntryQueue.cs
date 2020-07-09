using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class EntryQueue
    {
        public static List<TransactionOrder> TransactionQueue { get; }

        public static bool AddToQueue(TransactionOrder transaction)
        {
            var isDuplicated = TransactionQueue.Any(i => i.TransactionForm.Id == transaction.Id);

            if (!isDuplicated)
            {
                TransactionQueue.Add(transaction);
                return true;
            }
            return false;
        }
        public static void RemoveFromQueue(TransactionOrder transaction)
        {
            TransactionQueue.Remove(transaction);
        }

    }
}