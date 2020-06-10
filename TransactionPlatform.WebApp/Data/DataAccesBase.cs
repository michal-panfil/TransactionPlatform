using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public class DataAccesBase : IDataAcces
    {
        public TransactionContext Context { get; set; }
       

        public DataAccesBase( )
        {
        }

        public async Task<List<Instrument>> GetAllInstrumentsAsync()
        {
            var instruments = Context.Instruments.ToList();

            return instruments;


        }
    }
}
