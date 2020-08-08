using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionPlatform.TransactionService.Models
{
    public class TransactionMaker
    {
        //save transaction to DB
        //Sent notification
        //Sent request to api to update wallet

        public void MakeTransaction(Dictionary<Order, Order> transactions)
        {
            foreach (var trans in transactions)
            {
                SaveTransaction(trans);
                UpdateWallets(trans);
                SentNotifications(trans);
            }

        }
        private void SaveTransaction(KeyValuePair<Order, Order> trans)
        {
            //to mongo
            throw new NotImplementedException();
        }
        private void UpdateWallets(KeyValuePair<Order, Order> trans)
        {
            //callappi
            throw new NotImplementedException();
        }
        private void SentNotifications(KeyValuePair<Order, Order> trans)
        {
            //create email sender
            throw new NotImplementedException();
        }
    }
}