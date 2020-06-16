using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.WebApp.Controllers
{
    public class TransactionServiceController : Controller
    {
        public async Task<List<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>> GetAllInstrumentPrices()
        {
            var wcfClient = new MyWcfServices.Service1Client();
            var wcfClient1 = new ServiceReference2.Service1Client();
            var pricesTask = wcfClient1.GetPriceOfAllInstrumentsAsync();
            var apiresult = await pricesTask;
            var result = apiresult.Cast<TransactionPlatform.DomainLibrary.Dtos.InstrumentPriceDto>();

            return result.ToList();
        }
    }
}