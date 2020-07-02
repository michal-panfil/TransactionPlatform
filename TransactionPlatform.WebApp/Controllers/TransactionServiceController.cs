using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.WebApp.Models;
using ServiceReference1;

namespace TransactionPlatform.WebApp.Controllers
{
    public class TransactionServiceController : Controller
    {
         private readonly ITransactionService serviceClient;
        private readonly UserManager<ApplicationUser> userManager;

        public TransactionServiceController(UserManager<ApplicationUser> userManager)
        {
             serviceClient = new TransactionServiceClient() ;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<List<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>> GetAllInstrumentPrices()
        {
            var pricesTask = serviceClient.GetPriceOfAllInstrumentsAsync();
            var apiresult = await pricesTask;
            var result = apiresult.Cast<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>();

            return result.ToList();
        }
        [HttpPost]
        public async Task<bool> BuyInstrument(string ticker, float price, int volumen )
        {
            if(ticker != null &&  price > 0  && volumen > 0)
            {
                var userName = User.Identity.Name;
                var user = await userManager.FindByNameAsync(userName);

                var transDto = new TransactionFormDto()
                {
                    Ticker = ticker,
                    Price = price,
                    Volumen = volumen,
                    TransactionTime = DateTime.Now,
                    UserId = user.Id,
                    TransType = TransactionType.Buy

                };
                var pricesTask =  serviceClient.AcceptTransactionAsync(transDto);
                return await pricesTask;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> SellInstrument(string ticker, float price, int volumen)
        {
            if (ticker != null && price > 0 && volumen > 0)
            {
                var userName = User.Identity.Name;
                var user = await userManager.FindByNameAsync(userName);

                var transDto = new TransactionFormDto()
                {
                    Ticker = ticker,
                    Price = price,
                    Volumen = volumen,
                    TransactionTime = DateTime.Now,
                    UserId = user.Id,
                    TransType = TransactionType.Sell

                };
                var pricesTask = serviceClient.AcceptTransactionAsync(transDto);
                return await pricesTask;
            }
            return false;
        }
    }

    
}