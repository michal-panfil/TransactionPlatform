using System.Collections.Generic;
using System.Linq;
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
        public List<Instrument> GetAllInstruments()
        {
            var instruments = context.Instruments.ToList();
            return instruments;
        }

        public Instrument GetInstrumentByTicker(string ticker)
        {
            var instrument = context.Instruments.Where(i => i.Ticker == ticker).FirstOrDefault();
            return instrument;
        }
    }
}
