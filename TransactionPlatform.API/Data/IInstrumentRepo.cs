using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.API.Data
{
    public interface IInstrumentRepo
    {
        Task<Instrument> GetInstrumentByTicker(string Ticker);
        Task<List<Instrument>> GetAllInstruments();
    }
}
