using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public class CirculatingMedium {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }


        public float RatioToBaseMedium { get; set; }

        public decimal AvailableAmount { get; set; }

        public decimal BlockedAmount { get; set; }

        public DateTime LastChangeDt { get; set; }
        public int WalletId { get; set; }
        [JsonIgnore]
        public virtual Wallet StandardWallet { get; set; }
        
    }
}
