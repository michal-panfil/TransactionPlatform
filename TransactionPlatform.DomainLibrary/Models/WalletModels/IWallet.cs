using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public interface  IWallet
    {
        int Id { get; set; }
         string UserId { get; set; }

        List<IAsset> Assets { get; set; }

        ICirculatingMedium Currency { get; set; }
        
        DateTime CreateDT { get; set; }
        DateTime CloseDT { get; set; }

        string PayOut();
    }
}
