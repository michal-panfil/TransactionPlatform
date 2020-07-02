using System;
using System.Collections.Generic;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public class DemoWallet : IWallet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<IAsset> Assets { get; set; }
        public ICirculatingMedium Currency { get; set; }
        public DateTime CreateDT { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CloseDT { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string PayOut()
        {
            return "You can't payout cash. It is demoAccount!";
        }
    }
}
