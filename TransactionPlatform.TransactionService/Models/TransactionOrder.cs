using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class TransactionOrder
    {
        public Guid Id { get; set; }
        public TransactionFormDto TransactionForm { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime ReceivedDT { get; set; }
        public DateTime DoneDT { get; set; }
        public bool IsValid { get; set; }
    }
}