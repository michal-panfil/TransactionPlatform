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
        public async Task<IActionResult> GetWallet(string id)
        {
            var result = await repo.GetWalletByUserId(id);

            return Ok(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Wallet> AddWallet(Wallet wallet)
        {
            var result = await repo.AddWallet(wallet);

            return result;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<string> ChargeCreditWallt(ChargeWalletDto dto)
        {
            var result = await repo.ChargeWallet(dto.UserId, dto.Amount);

            return result.ToString();
        }


        [HttpPost]
        [Route("[action]")]

        public async Task<bool> AddAssetToWallet(OrderFormDto transaction)
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
            var result = await repo.AddAssetToWallet(transaction.UserId, asset);

            return false;
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<bool> RemoveAssetFromWallet(OrderFormDto transaction)
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
            var result = await repo.RemoveAssetFromWallet(transaction.UserId, asset);

            return false;
        }
    }
}