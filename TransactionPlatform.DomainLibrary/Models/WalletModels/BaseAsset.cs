using Newtonsoft.Json;
using System;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public class BaseAsset
    {

        public int Id { get; set; }
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public decimal BuyPrice { get; set; }
        public int Volumen { get; set; }
        public DateTime BuyDT { get; set; }
        public DateTime? SaleDT { get; set; }
        public int WalletId { get; set; }
        [JsonIgnore]
        public virtual Wallet StandardWallet { get; set; }



    }
}
