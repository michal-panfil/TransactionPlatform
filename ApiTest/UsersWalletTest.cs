using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.API.Controllers;
using TransactionPlatform.API.Data;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace ApiTest
{
    [TestFixture]
   public  class UsersWalletTest
    {

        //this test prepeare data for testing puroses;
        [Test, Explicit]
        public void CreateWalletTets()
        {
            var connectionStrting = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=C:\\Users\\Michal\\OneDrive\\Dokumenty\\TransactionDB.mdf;Integrated Security=True;Connect Timeout=30";
            var optionBuiler = new DbContextOptionsBuilder<ApiDbContext>();
            optionBuiler.UseSqlServer(connectionStrting);

            var ctx = new ApiDbContext(optionBuiler.Options);
            var ctr = new UsersWalletController(ctx);

            var walletBuy = new Wallet("b8846332-7262-44b1-ba60-0b92552f0b3a", 100000);
            var walletSell = new Wallet("b8846332-7262-44b1-ba60-0b92552f0b3b", 0);


          ///  var x = ctr.AddWallet(walletBuy).Result;
        //    var y = ctr.AddWallet(walletSell).Result;

            var order = new OrderForm("TST", 5.55f, 100, "b8846332-7262-44b1-ba60-0b92552f0b3b", DateTime.Now, OrderType.Buy);

          var z =   ctr.AddAssetToWallet(order).Result;

        }
    }
}
