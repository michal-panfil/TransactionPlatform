using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Dtos
{
    public enum TransactionType
    {
        Sell,
        Buy
    }
    public class TransactionFormDto
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public float Price { get; set; }
        public int Volumen { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionTime { get; set; }
        public TransactionType TransType { get; set; }


    }
}
