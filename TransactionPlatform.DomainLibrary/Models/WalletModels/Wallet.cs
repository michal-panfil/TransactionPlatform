using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public class Wallet  
    {
        [Key]
        public int WalletId { get; set; }
        public string UserId { get; set; }
        public virtual List<BaseAsset> Assets { get; set; }

        public DateTime CreateDT { get; set; }
        public DateTime CloseDT { get; set; }
        public virtual CirculatingMedium CirculatingMedium { get; set; }



        public Wallet(){}
        public Wallet(string userId, decimal amont, CirculatingMedium medium = null)
        {
            UserId = userId;
            Assets = new List<BaseAsset>();
            CirculatingMedium = medium ?? new Cash(amont);
            CreateDT = DateTime.Now;
        }


        public string PayOut()
        {
            return "There's your cash";
        }
    }
}
