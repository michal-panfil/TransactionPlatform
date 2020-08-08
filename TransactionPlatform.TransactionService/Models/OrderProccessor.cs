using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TransactionPlatform.TransactionService.Models
{
    public sealed class OrderProccessor
    {

        private static readonly object padlock = new object();
        private static OrderProccessor instance = null;
        public static OrderProccessor Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OrderProccessor();
                    }
                    return instance;
                }
            }
        }
        
        // it calass is resposinble for workflow of orders and moving them from one stage to another
        private OrderProccessor()
        {
            Task.Run(()=>
            {
                while (true)
                {
                    var wasThereAnythingToDo = MoveOrdersFromEntryQueueToMainQueue();
                    if (!wasThereAnythingToDo)
                    {
                        Task.Delay(5000);
                    }
                }


            });

            Task.Run(() =>
            {
                while (true)
                {
                    var wasThereAnythingToDo = MatchOrdersOnFloor();
                    if (!wasThereAnythingToDo)
                    {
                        Task.Delay(5000);
                    }
                }
            }); 
            
            Task.Run(() =>
            {
                while (true)
                {
                    var wasThereAnythingToDo = ProcessTransaction();
                    if (!wasThereAnythingToDo)
                    {
                        Task.Delay(5000);
                    }
                }
            });
        }

        private bool MoveOrdersFromEntryQueueToMainQueue()
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

        private bool MatchOrdersOnFloor()
        {
            return TheFloor.Instance.MatchTransactionOrder();
        }

        private bool ProcessTransaction()
        {
            //move matching orders from
            return false;
        }

    }
}