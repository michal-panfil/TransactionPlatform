using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionPlatform.TransactionService.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Order SellOrder { get; set; }
        public Order BuyOrder { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction( Order sellOrder, Order buyOrder)
        {
            Id = new Guid();
            SellOrder = sellOrder;
            BuyOrder = buyOrder;
            TransactionDate = DateTime.Now;
        }
    }
}