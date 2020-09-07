using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TransactionPlatform.TransactionService.DAL;

namespace TransactionPlatform.TransactionService.Models
{
    public class TransactionMaker
    {
        private IDBContext DB { get; set; }
        private IApiCaller Api { get; set; }
        public TransactionMaker()
        {
            DB = new MongoContext();
            Api = new ApiCaller();
        }

        public void MakeTransactions(List<Transaction> transactions)
        {
            SaveTransaction(transactions);
            MoveOrderInDB(transactions);
            foreach (var trans in transactions)
            {
                DB.ChangeStatus(trans.BuyOrder, OrderStatus.Done);
                DB.ChangeStatus(trans.SellOrder, OrderStatus.Done);

                UpdateWallets(trans);
            }

        }

        private void MoveOrderInDB(List<Transaction> transactions)
        {
            var orders = transactions.Select(t => t.SellOrder).ToList();
            orders.AddRange(transactions.Select(t => t.BuyOrder).ToList());
            DB.MoveOrder(orders);
        }
        
        private void SaveTransaction(List<Transaction> transactions)
        {
            DB.AddTransactions(transactions);
            
        }
        private async Task<bool> UpdateWallets(Transaction trans)
        {
            
            var t1 = Api.ChargeWallet(trans.SellOrder.OrderForm);
            var t2 = Api.MoveAsset(trans.SellOrder.OrderForm);

            var t3 = Api.ChargeWallet(trans.BuyOrder.OrderForm);
            var t4 = Api.MoveAsset(trans.BuyOrder.OrderForm);


            Task[] tasks = new Task[] { t1, t2, t3, t4 };
            Task.WaitAll(tasks);
            return true;
        }
    }
}