using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.TransactionService.Models
{
    public static class EntryOrderValidator
    {
        public static bool CheckFormDataCompleteness(OrderForm form)
        {
            if (string.IsNullOrWhiteSpace((form.Id).ToString()) ||
                string.IsNullOrEmpty(form.Ticker) ||
                form.Price == 0 ||
                form.Volumen == 0 ||
                string.IsNullOrWhiteSpace(form.UserId) ||
                form.TransactionTime == null ||
                form.OrderType == OrderType.Undefined)
            {
                return false;
            }
            return true;

        }

        public static bool CheckFormDataSemantic(OrderForm form)
        {
            
            var context = new ValidationContext(form, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(form, context, results, true);
            if(isValid == true)
            {
                isValid = form.TransactionTime > DateTime.Now.AddDays(-2) && form.TransactionTime < DateTime.Now.AddHours(1) ? true : false;
            }
            return isValid;
        }
       
        public static bool ValidateWallet(OrderForm form, Wallet wallet)
        {
            if(form.OrderType == OrderType.Sell)
            {
                var walletAsset = wallet.Assets.Where(a => a.Name == form.Ticker).FirstOrDefault();
                var isValid = walletAsset != null && walletAsset.Volumen >= form.Volumen;
                return isValid;

            }
            else if (form.OrderType == OrderType.Buy)
            {
                var neededCash = form.Price * form.Volumen;
                var isValid = wallet.CirculatingMedium.AvailableAmount >= (decimal)neededCash;

                return isValid;
            }
            else
            {
                return false;
            }

        }
    }
}