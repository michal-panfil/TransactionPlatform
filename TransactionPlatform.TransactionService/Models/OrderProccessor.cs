using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TransactionPlatform.TransactionService.DAL;

namespace TransactionPlatform.TransactionService.Models
{
    public sealed class OrderProccessor
    {

        private static readonly object padlock = new object();
        private static OrderProccessor instance = null;
        public IDBContext DB; 
        
        public static OrderProccessor Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OrderProccessor();
                        
                        instance.DB = new MongoContext();
                    }
                    return instance;
                }
            }
        }

        public async Task ProcessUnfinishedOrders()
        {
            //TODO:
            //find in DB all transactions that are not done and cancelled.
            //group those and add to queues and dictionaries due to their status

        //    throw new NotImplementedException();
        }

        // it calass is resposinble for workflow of orders and moving them from one stage to another
        private OrderProccessor()
        {
          
        }

        public async Task<bool> MoveOrdersFromEntryQueueToMainQueue()
        {
         
            var movedAnyTransactions = false;
            while (EntryQueue.TransactionQueue.Count > 0)
            {
                var transaction = EntryQueue.GetNextTransaction();
                TheFloor.Instance.AddOrderToQueue(transaction);
                movedAnyTransactions = true;
            }

            return movedAnyTransactions;
        }

        public  bool MatchOrdersOnFloor()
        {
            return   TheFloor.Instance.MatchTransactionOrder();
        }

        public  bool ProcessTransaction()
        {
            var transactions = TheFloor.Instance.MatchingTransactions;
            TheFloor.Instance.ClearMatchingTransactions();
            var transactionMaker = new TransactionMaker();
            transactionMaker.MakeTransactions(transactions);
            
            return transactions.Count > 0 ? true : false;
        }
        public static void StopProccesingOrder(Guid orderId)
        {
            throw new NotImplementedException();
            //find in which point of the procces is order and remove it from the local storage
            //move orders from ordercollection to Proccessed Orders
                

        }

  
    }
}