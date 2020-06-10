using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Models
{
    public class DashBoardDto
    {
        public Wallet UserWallet { get; set; }
        public List<Instrument> Instruments { get; set; }
        public DashBoardDto()
        {
            Instruments = new List<Instrument>();
        }

    }
}
