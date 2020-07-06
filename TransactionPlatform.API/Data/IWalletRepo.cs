using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.API.Data
{
    interface IWalletRepo
    {
        Task<Wallet> GetWalletByUserId(string id);
        Task<Wallet> AddWallet(Wallet wallet);
        Task<bool> ChargeWallet(string userId, decimal price);
        Task<bool> AddAssetToWallet(string userId, BaseAsset asset);
        Task<bool> RemoveAssetFromWallet(string userId, BaseAsset asset);
    }
}
