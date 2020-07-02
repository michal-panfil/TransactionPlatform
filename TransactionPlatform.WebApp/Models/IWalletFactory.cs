using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public interface IWalletFactory
    {
        BaseWallet CreateWallet();
    }
}
