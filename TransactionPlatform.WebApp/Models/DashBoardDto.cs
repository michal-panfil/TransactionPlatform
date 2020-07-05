using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.WebApp.Models
{
    public class DashboardDto
    {
        public Wallet UserWallet { get; set; }
        public List<Instrument> Instruments { get; set; }
        public DashboardDto()
        {
            Instruments = new List<Instrument>();
        }
    }
}
