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
                    MoveOrdersFromEntryQueueToMainQueue();
                }


            });

            Task.Run(() =>
            {
                while (true)
                {
                    MatchOrdersOnFloor();
                }


            }); 
            
            Task.Run(() =>
            {
                while (true)
                {
                    ConfirmedOrders();
                }


            });
        }

        private void ConfirmedOrders()
        {
            throw new NotImplementedException();
        }

        private void MatchOrdersOnFloor()
        {
            throw new NotImplementedException();
        }

        private void MoveOrdersFromEntryQueueToMainQueue()
        {
            throw new NotImplementedException();
        }

        
    }
}