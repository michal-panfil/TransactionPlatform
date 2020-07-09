using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class EntryQueue
    {
        public static List<TransactionFormDto> TransactionQueue { get; }

        public void AddToQueue(TransactionFormDto transaction)
        {
            var isDuplicated
            TransactionQueue.Add(transaction);
        }
        public void RemoveFromQueue(TransactionFormDto transaction)
        {
            TransactionQueue.Remove(tr)
        }

    }
}