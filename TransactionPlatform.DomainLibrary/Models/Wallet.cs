using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        public decimal Cash { get; set; }

        public decimal EstimatedValue { get => CalculateEstimatedValue(); }
        public List<Asset> Assets { get; set; }

        public decimal SumInvestedMoney { get; set; }
        public decimal ROI => Math.Round(((EstimatedValue - SumInvestedMoney) / SumInvestedMoney),1);

        public Wallet()
        {
            Assets = new List<Asset>();
        }

        private decimal CalculateEstimatedValue()
        {
            var estimatedValue = 0M;
            if(Assets != null)
            {
                foreach (var asset in Assets)
                {
                    estimatedValue += asset.CurrentInstrumentValue();
                }
            }
            return estimatedValue;
            
        }
    }

    
}
