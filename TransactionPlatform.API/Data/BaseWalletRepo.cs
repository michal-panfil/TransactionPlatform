using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.API.Data
{
    public class BaseWalletRepo : IWalletRepo
    {
        private readonly ApiDbContext Context;

        public BaseWalletRepo(ApiDbContext context)
        {
            Context = context;
        }

        public bool AddAssetToWallet(string userId, BaseAsset asset)
        {
            
            var wallet = Context.Wallets.Where(w => w.UserId == userId).Include(w => w.Assets).SingleOrDefault();
            wallet.Assets.Add(asset);
            Context.SaveChanges();
            return true;

        }

        public Wallet AddWallet(Wallet wallet)
        {
            Context.Wallets.Add(wallet);
            Context.SaveChanges();
            return wallet; 
        }

        public bool ChargeWallet(string userId, decimal price)
        {
            var wallet = Context.Wallets.Where(w => w.UserId == userId).Include(w => w.CirculatingMedium).SingleOrDefault();
            
            if(price > 0)
            {
                if (wallet.CirculatingMedium.AvailableAmount > price)
                {
                    wallet.CirculatingMedium.AvailableAmount -= price;
                    Context.SaveChanges();
                    return true;
                }

            }
            else
            {
                //
                wallet.CirculatingMedium.AvailableAmount -= price;
                Context.SaveChanges();
                return true;
            }
            
            

            return false;

        }

        public Wallet GetWalletByUserId(string userId)
        {
            var wallet = Context.Wallets.Where(w => w.UserId == userId).Include(w => w.CirculatingMedium).Include(w => w.Assets).SingleOrDefault();
          
            return wallet;
        }

        public object RemoveAssetFromWallet(string userId, BaseAsset asset)
        {
            var wallet = Context.Wallets.Where(w => w.UserId == userId).Include(w => w.Assets).SingleOrDefault();
            var assetToRemove = wallet.Assets.Where(a => a.Name.Equals(asset.Name)).FirstOrDefault(); ;
            wallet.Assets.Remove(assetToRemove);
            Context.SaveChanges();
            return true;
        }
    }
}
