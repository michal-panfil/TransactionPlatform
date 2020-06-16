using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TransactionPlatform.WebApp.Controllers
{
    public class WalletWcfController : Controller
    {
        public async Task<float> Index()
        {
            var client = new ServiceReference1.Service1Client();
     
            var wcfTask = client.GetPriceOfInstrumentAsync(10);
            var x = await  wcfTask;
            return x;
        }
    }
}