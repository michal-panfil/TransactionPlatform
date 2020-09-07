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
        private List<Order> FloorQueue = new List<Order>();

        //TODO : encapsulate it- there shoud be accesing set method
        public List<Transaction> MatchingTransactions = new List<Transaction>();

        public void AddOrderToQueue(Order order)
        {
            CheckedQueue = false;
            FloorQueue.Add(order);
        }
        public bool MatchTransactionOrder()
        {
            var foundMatch = false;
            if (!CheckedQueue)
            {
                foreach (var order in FloorQueue)
                {
                    var generalMatchs = FloorQueue.Where(o => o.OrderForm.Ticker == order.OrderForm.Ticker
                   && o.OrderForm.OrderType != order.OrderForm.OrderType);

                    if (order.OrderForm.OrderType == OrderType.Buy)
                    {
                        foundMatch = MatchBuyOrders(foundMatch, order, generalMatchs);
                    }
                    else
                    {
                        foundMatch = MatchSellOrders(foundMatch, order, generalMatchs);
                    }
                }
            }
            
            CheckedQueue = true;
            return foundMatch;
        }

        private bool MatchSellOrders(bool foundMatch, Order order, IEnumerable<Order> generalMatchs)
        {
            var finalMatchs = generalMatchs.Where(m => m.OrderForm.Price >= order.OrderForm.Price).OrderBy(o => o.OrderForm.Price).ThenBy(o => o.ReceivedDT);
            var theMatch = finalMatchs?.FirstOrDefault();

            if (theMatch != null)
            {
                foundMatch = true;
                MoveMatchingOrders(order, theMatch);
            }

            return foundMatch;
        }
        private bool MatchBuyOrders(bool foundMatch, Order order, IEnumerable<Order> generalMatchs)
        {
            var finalMatchs = generalMatchs.Where(m => m.OrderForm.Price <= order.OrderForm.Price).OrderBy(o => o.OrderForm.Price).ThenBy(o => o.ReceivedDT);
            var theMatch = finalMatchs?.FirstOrDefault();

            if (theMatch != null)
            {
                foundMatch = true;
                MoveMatchingOrders(order, theMatch);
            }
            return foundMatch;
        }

        internal void ClearMatchingTransactions()
        {
            MatchingTransactions = new List<Transaction>();
        }

        private void MoveMatchingOrders(Order order, Order theMatch)
        {
            var sellOrder = order.OrderForm.OrderType == OrderType.Sell ? order : theMatch;
            var buyOrder = order.OrderForm.OrderType == OrderType.Buy ? order : theMatch;
            var transaction = new Transaction(sellOrder, buyOrder);
            MatchingTransactions.Add(transaction);
            FloorQueue.Remove(order);
            FloorQueue.Remove(theMatch);
        }

        
    }
}