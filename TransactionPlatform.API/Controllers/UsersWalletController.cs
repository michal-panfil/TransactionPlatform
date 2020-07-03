using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models.WalletModels;
using Microsoft.EntityFrameworkCore;
using TransactionPlatform.API.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace TransactionPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWalletController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly IWalletRepo repo;

        public UsersWalletController(ApiDbContext context)
        {
            this.context = context;
            repo = new BaseWalletRepo(context);

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetWallet(string id)
        {
            var result = repo.GetWalletByUserId(id);

            return Ok(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        [HttpPost]
        [Route("[action]")]
        public Wallet AddWallet(Wallet wallet)
        {
            var result = repo.AddWallet(wallet);

            return result;
        }


        [HttpPost]
        [Route("[action]")]
        public string ChargeWallet(TransactionFormDto transaction)
        {
            var price = transaction.Price * transaction.Volumen;
            var result = repo.ChargeWallet(transaction.UserId, price);

            return result.ToString();
        }


        [HttpPost]
        [Route("[action]")]

        public bool AddAssetToWallet(TransactionFormDto transaction)
        {

            var asset = new BaseAsset()
            {
                InstrumentId = context.Instruments.Where(i => i.Ticker == transaction.Ticker).FirstOrDefault().Id,
                Name = transaction.Ticker,
                BuyPrice = (decimal)transaction.Price,
                Volumen = transaction.Volumen,
                BuyDT = transaction.TransactionTime,
                SaleDT = null,
            };
            var result = repo.AddAssetToWallet(transaction.UserId, asset);

            return false;
        }

    }
}