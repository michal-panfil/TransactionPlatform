using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.API.Data;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly IInstrumentRepo repo;

        public InstrumentController(ApiDbContext context, IInstrumentRepo repo)
        {
            this.context = context;
            this.repo = repo;
        }
        [HttpGet]
        [Route("[action]")]
        public List<Instrument> GetInstruments()
        {
            /* var instruments = new List<Instrument>();
             instruments.Add(new Instrument() { Id = 2, Name = "Corn US", Ticker = "CUS", Description = "Corn from midlle of USA wigh quality" });
             instruments.Add(new Instrument() { Id = 3, Name = "Platinum", Ticker = "PLM", Description = "Platinum for electronic puroses" });
             instruments.Add(new Instrument() { Id = 4, Name = "Caffe Arabica", Ticker = "CA", Description = "Coffe rady to be burn, Arabbica type " });
             instruments.Add(new Instrument() { Id = 1, Name = "Oil Barnd 3", Ticker = "OB3", Description = "The clearest and moste value cartify oil" });
             instruments.Add(new Instrument() { Id = 5, Name = "Steal", Ticker = "STL", Description = "Certificated construction steal" });
             instruments.Add(new Instrument() { Id = 6, Name = "Wood", Ticker = "WOD", Description = "Brasilian wood - long size" });
             */
            var instruments = repo.GetAllInstruments();
            return instruments;
        }
        
        [HttpGet]
        [Route("[action]")]

        public Instrument GetInstrumentByTicker(string ticker)
        {

            var instrument = repo.GetInstrumentByTicker(ticker);
            return instrument;
        }

    }
}