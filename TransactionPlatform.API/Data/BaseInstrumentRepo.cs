using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.API.Data
{
    public class BaseInstrumentRepo : IInstrumentRepo
    {
        private readonly ApiDbContext context;

        public BaseInstrumentRepo(ApiDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Instrument>> GetAllInstruments()
        {
            var instruments = await context.Instruments.ToListAsync();
            return instruments;
        }

        public async Task<Instrument> GetInstrumentByTicker(string ticker)
        {
            var instrument = await context.Instruments.Where(i => i.Ticker == ticker).FirstOrDefaultAsync();
            return instrument;
        }
    }
}
