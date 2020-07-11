using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Dtos
{
    public enum TransactionType
    {
        Undefined = 0,
        Sell,
        Buy
    }
    public class TransactionFormDto
    {
        [Required]
        [RegularExpression(@"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}")]
        public Guid Id { get; set; }

        [Required]
        public string Ticker { get; set; }

        [Range(0.1, 100000)]
        public float Price { get; set; }

        [Range(1, 100000)]
        public int Volumen { get; set; }

        [Required]
        [RegularExpression(@"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}")]
        public string UserId { get; set; }

        [Required]
        public DateTime TransactionTime { get; set; }

        public TransactionType TransType { get; set; }

        public TransactionFormDto()
        {

        }
        public TransactionFormDto(string ticker, float price, int volumen, string userId, DateTime transactionTime, TransactionType transType)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            Price = price; 
            Volumen = volumen;
            UserId = userId;
            TransactionTime = transactionTime;
            TransType = transType;
        }

       


    }
}
