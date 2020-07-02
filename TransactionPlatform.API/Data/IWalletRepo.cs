using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.API.Data
{
    interface IWalletRepo
    {
        Wallet GetWalletByUserId(string id);
        Wallet AddWallet(Wallet wallet);
        bool ChargeWallet(string userId, float price);
        bool AddAssetToWallet(string userId, BaseAsset asset);
    }
}
