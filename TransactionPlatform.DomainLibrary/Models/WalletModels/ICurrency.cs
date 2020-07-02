using System;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public interface ICirculatingMedium {

        string Name { get; set; }
        string Short { get; set; }
        float RatioToBaseMedium { get; }
        decimal AvailableAmount { get; }
        decimal BlockedAmount { get; }
        DateTime LastChangeDt { get; set; } 

        void AddAvailiableAmount (decimal amount);
        void PayOutAvailableAmount(decimal amount);
        void BlockAmountDueToTransaction(decimal amount);
        void UnblockAmountDueToTransaction(decimal amount);
        void TakeOutAmountDueToTransaction(decimal amount);
        

    }
}
