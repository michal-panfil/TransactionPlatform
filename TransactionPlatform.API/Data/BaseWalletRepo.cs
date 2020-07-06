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

        public async Task<bool> AddAssetToWallet(string userId, BaseAsset asset)
        {

            var wallet = await Context.Wallets.Where(w => w.UserId == userId).Include(w => w.Assets).SingleOrDefaultAsync();
            if(wallet != null)
            {
                wallet.Assets.Add(asset);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<Wallet> AddWallet(Wallet wallet)
        {
            await Context.Wallets.AddAsync(wallet);
            await Context.SaveChangesAsync();
            return wallet; 
        }

        public async Task<bool> ChargeWallet(string userId, decimal price)
        {
            var wallet = await Context.Wallets.Where(w => w.UserId == userId).Include(w => w.CirculatingMedium).SingleOrDefaultAsync();
            
            if(price > 0)
            {
                if (wallet.CirculatingMedium.AvailableAmount > price)
                {
                    wallet.CirculatingMedium.AvailableAmount -= price;
                    await Context.SaveChangesAsync();
                    return true;
                }
            }
            else
            {
                wallet.CirculatingMedium.AvailableAmount -= price;
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Wallet> GetWalletByUserId(string userId)
        {
            var wallet = await Context.Wallets.Where(w => w.UserId == userId).Include(w => w.CirculatingMedium).Include(w => w.Assets).SingleOrDefaultAsync();
            return wallet;
        }

        public async Task<bool> RemoveAssetFromWallet(string userId, BaseAsset asset)
        {
            var wallet = await Context.Wallets.Where(w => w.UserId == userId).Include(w => w.Assets).SingleOrDefaultAsync();
            var assetToRemove = wallet.Assets.Where(a => a.Name.Equals(asset.Name)).FirstOrDefault(); 
            wallet.Assets.Remove(assetToRemove);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
