using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class TheFloor
    {
        private static readonly object padlock = new object();
        private static TheFloor instance = null;
        public static TheFloor Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TheFloor();
                    }
                    return instance;
                }
            }
        }

        private bool CheckedQueue;
        private List<TransactionOrder> FloorQueue = new List<TransactionOrder>();

        public Dictionary<TransactionOrder, TransactionOrder> MatchingTransactions = new Dictionary<TransactionOrder, TransactionOrder>();

        public void AddOrderToQueue(TransactionOrder order)
        {
            CheckedQueue = false;
            FloorQueue.Add(order);
        }
        public bool MatchTransactionOrder()
        {
            var foundMatch = false;
           
            foreach (var order in FloorQueue)
            {
                var generalMatchs = FloorQueue.Where(o => o.TransactionForm.Ticker == order.TransactionForm.Ticker
               && o.TransactionForm.TransType != order.TransactionForm.TransType);

                if(order.TransactionForm.TransType == TransactionType.Buy)
                {
                    var finalMatchs = generalMatchs.Where(m => m.TransactionForm.Price <= order.TransactionForm.Price).OrderBy(o => o.TransactionForm.Price).ThenBy(o => o.ReceivedDT);
                    var theMatch = finalMatchs?.FirstOrDefault();
                    
                    if(theMatch != null)
                    {
                        foundMatch = true;
                        MatchingTransactions.Add(order, theMatch);
                        FloorQueue.Remove(order);
                        FloorQueue.Remove(theMatch);
                    }
                }
                else
                {
                    var finalMatchs = generalMatchs.Where(m => m.TransactionForm.Price >= order.TransactionForm.Price).OrderBy(o => o.TransactionForm.Price).ThenBy(o => o.ReceivedDT);
                    var theMatch = finalMatchs?.FirstOrDefault();

                    if (theMatch != null)
                    {
                        foundMatch = true;
                        MatchingTransactions.Add(order, theMatch);
                        FloorQueue.Remove(order);
                        FloorQueue.Remove(theMatch);
                    }
                }

            }
            return foundMatch;
        }

    }
}