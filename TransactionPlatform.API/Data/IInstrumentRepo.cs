using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.API.Data
{
    public interface IInstrumentRepo
    {
        Instrument GetInstrumentByTicker(string Ticker);
        List<Instrument> GetAllInstruments();
    }
}
