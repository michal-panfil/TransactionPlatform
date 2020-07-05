using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public interface IDataAcces
    {
        public TransactionContext Context { get; set; }
        Task<List<Instrument>> GetAllInstrumentsAsync();
    }
}
