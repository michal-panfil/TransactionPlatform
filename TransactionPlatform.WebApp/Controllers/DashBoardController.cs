using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.WebApp.Data;
using TransactionPlatform.WebApp.Models;

namespace TransactionPlatform.WebApp.Controllers
{
    public class DashBoardController : Controller
    {
        public DashBoardController(TransactionContext context)
        {
            Context = context;
        }

        public TransactionContext Context { get; }

        public async Task<IActionResult> Index()
        {
            var model = new DashBoardDto();
            var instruments = Context.Instruments.ToList();
            model.Instruments = instruments;
            /* 1.create dashboard DTO
             * 
             * async prepareInstrumentsDto()
             * 2.call db for all instrumetns
             * 3.convert instrunents in Dto
             * 4.add instruments to model
             * 
             * async prepareWalettDto(userId)
             * 5.Crate wallet
             * 6.call api for wallet data
             * 7.separtate assets and turn into assetdto
             * 8.build walletDto and  add assetsDto to it
             * 9.add walletDto to model
             * 
             * 10.await return model
             */



            var mockUp = new MockUpDashboardDto();
            var modelMU = mockUp.GetMockUpDashboard();
            
            return View(modelMU);
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