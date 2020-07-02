using System;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public class DumieCash : ICirculatingMedium
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Short { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float RatioToBaseMedium => throw new NotImplementedException();

        public decimal AvailableAmount => throw new NotImplementedException();

        public decimal BlockedAmount => throw new NotImplementedException();

        public DateTime LastChangeDt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddAvailiableAmount(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void BlockAmountDueToTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void PayOutAvailableAmount(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void TakeOutAmountDueToTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void UnblockAmountDueToTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
