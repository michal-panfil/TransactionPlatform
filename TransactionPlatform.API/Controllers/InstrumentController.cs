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
        public async Task<List<Instrument>> GetInstruments()
        {
            var instruments = await repo.GetAllInstruments();
            return instruments;
        }
        
        [HttpGet]
        [Route("[action]")]

        public async Task<Instrument> GetInstrumentByTicker(string ticker)
        {

            var instrument =  await repo.GetInstrumentByTicker(ticker);
            return instrument;
        }

    }
}