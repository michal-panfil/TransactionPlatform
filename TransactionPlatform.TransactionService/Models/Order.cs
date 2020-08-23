using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService.Models
{
    public class Order
    {

        public Order()
        {
            Id = Guid.NewGuid();
        }
        [BsonId]
        [BsonElement(elementName:"_id")]
        public Guid Id { get; set; }

        public OrderForm OrderForm { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime ReceivedDT { get; set; }

        public DateTime DoneDT { get; set; }

        public bool IsValid { get; set; }
    }
}