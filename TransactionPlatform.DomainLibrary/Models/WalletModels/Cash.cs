using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Models.WalletModels
{
    public class Cash : CirculatingMedium
    {

        public Cash()
        {

        }
        public Cash(decimal availableAmont )
        {
            Name = "cash - USD";
            Short = @"$ USD";
            AvailableAmount = availableAmont;
            BlockedAmount = 0;
            RatioToBaseMedium = 1;
            LastChangeDt = DateTime.Now;


        }
        //TODO: Implement Wallet history


        public void AddAvailiableAmount(decimal amount)
        {
          
            AvailableAmount += amount;
        }

        public void BlockAmountDueToTransaction(decimal amount)
        {
            if (AvailableAmount < amount)
            {
                throw new ArgumentException("Avalible currency is smaller than amount you are going to blocked ");
            }
            else
            {
                AvailableAmount -= amount;
                BlockedAmount += amount;
                LastChangeDt = DateTime.Now;
            }
        }

        

        public void ChangeAmountDueToTransaction(decimal amount)
        {
            if(amount < 0 && amount > ( AvailableAmount * (-1))){
                throw new ArgumentException("Transaction amount larger thay available amout ");
            }
            else
            {
                AvailableAmount += amount;
                LastChangeDt = DateTime.Now;
            }
            

        }

        public void PayOutAvailableAmount(decimal amount)
        {
            if(amount > AvailableAmount)
            {
                throw new ArgumentException("Payout amount larger thay available amout ");
            }
            else
            {
                AvailableAmount -= amount;
            }
        }

        

        

        public void TakeOutAmountDueToTransaction(decimal amount)
        {
            if (amount > BlockedAmount)
            {
                throw new ArgumentException("Transaction amount is larger thay you have blocked on you account ");
            }
            else
            {
                BlockedAmount -= amount;
            }
        }

        public void UnblockAmountDueToTransaction(decimal amount)
        {
            if (amount > BlockedAmount)
            {
                throw new ArgumentException("Transaction amount is larger thay you have blocked on you account ");
            }
            else
            {
                BlockedAmount -= amount;
                AvailableAmount += amount;
            }
        }

        
    }
}
