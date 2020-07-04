using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Dtos
{
    public class ChargeWalletDto
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
