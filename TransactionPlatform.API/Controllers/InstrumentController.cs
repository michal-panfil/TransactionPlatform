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