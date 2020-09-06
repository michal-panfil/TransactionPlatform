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
            //find in which point of the procces is it and remove it from the local storage
            //remove orders from ordercollection to Proccessed Orders
                

        }

      /*  public async Task Execute(IJobExecutionContext context)
        {
          var p1 = MoveOrdersFromEntryQueueToMainQueue();
          var p2 = Task.Run(()=> MatchOrdersOnFloor());
          var p3 = Task.Run(()=>ProcessTransaction());
          var p4 = ProcessUnfinishedOrders();

            await p1;
            await p2;
            await p3;
            await p4;
        }*/
    }
}