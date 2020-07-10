using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public static class EntryOrderValidator
    {
        // check if data from form are correct
        public static bool CheckFormDataCompleteness(TransactionFormDto form)
        {
            if (string.IsNullOrWhiteSpace((form.Id).ToString()) ||
                string.IsNullOrEmpty(form.Ticker) ||
                form.Price == 0 ||
                form.Volumen == 0 ||
                string.IsNullOrWhiteSpace(form.UserId) ||
                form.TransactionTime == null ||
                form.TransType == TransactionType.Undefined)
            {
                return false;
            }
            return true;

        }

        public static bool CheckFormDataSemantic(TransactionFormDto form)
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
       
        // Check if he's got enough money
        public static bool ValidateWallet(string userId)
        {
            return false;
        }
    }
}