using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.WebApp.Data;
using TransactionPlatform.WebApp.Models;
using System.Net.Http;

namespace TransactionPlatform.WebApp.Controllers
{
    public class DashBoardController : Controller
    {
        public DashBoardController(TransactionContext context, IDataAcces data)
        {
            Data = data;
            Data.Context = context;
        }

        public TransactionContext Context { get; }
        public IDataAcces Data { get; }

        public async Task<IActionResult> Index()
        {
            var model = new DashBoardDto();
            var apiCaller = new ApiCaller();
            
            var walletTsk =  apiCaller.GetWalletFromAPI(1);
            var instrumentsTsk = apiCaller.GetInstrumentsFromAPI();

            model.Instruments = await instrumentsTsk;
            model.UserWallet = await walletTsk;         
            return View(model);

        }
    }
}

/* SEEDING
 * Context.Instruments.AddRange(new List<Instrument>
            {
                new Instrument() {Id = 1, Name = "Oil Barnd 3", Ticker= "OB3", Description ="The clearest and moste value cartify oil"},
            new Instrument() { Id = 2, Name = "Corn US", Ticker = "CUS", Description = "Corn from midlle of USA wigh quality" },
            new Instrument() { Id = 3, Name = "Platinum", Ticker = "PLM", Description = "Platinum for electronic puroses" },
            new Instrument() { Id = 4, Name = "Caffe Arabica", Ticker = "CA", Description = "Coffe rady to be burn, Arabbica type " },
            new Instrument() { Id = 5, Name = "Steal", Ticker = "STL", Description = "Certificated construction steal" },
            new Instrument() { Id = 6, Name = "Wood", Ticker = "WOD", Description = "Brasilian wood - long size" },
            new Instrument() { Id = 7, Name = "Natural GAS", Ticker = "NGS", Description = "Rusian low quality natural gas" },
            new Instrument() { Id = 8, Name = "Wather", Ticker = "WTR", Description = "Contract 6 mont for water" },
        });
            Context.SaveChanges();
*/