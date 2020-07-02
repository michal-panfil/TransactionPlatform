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
            //Context.Medium.Add(wallet.CirculatingMedium);
            Context.SaveChanges();
            return wallet; 
        }

        public bool ChargeWallet(string userId, float price)
        {
            var wallet = Context.Wallets.Where(w => w.UserId == userId).Include(w => w.CirculatingMedium).SingleOrDefault();
            if(wallet.CirculatingMedium.AvailableAmount > (decimal)price)
            {
                wallet.CirculatingMedium.AvailableAmount -= (decimal)price;
                Context.SaveChanges();
                return true;
            }

            return false;

        }

        public Wallet GetWalletByUserId(string userId)
        {
            var wallet = Context.Wallets.Where(w => w.UserId == userId).Include(w => w.CirculatingMedium).Include(w => w.Assets).SingleOrDefault();
           // var wallet = Context.Wallets.Where(w => w.UserId == userId).SingleOrDefault();//.Include(w => w.Currency).SingleOrDefault();
           // wallet.Assets = Context.Assets.Where(a => a.StandardWalletId == wallet.Id).ToList();
          
            return wallet;
        }
    }
}
