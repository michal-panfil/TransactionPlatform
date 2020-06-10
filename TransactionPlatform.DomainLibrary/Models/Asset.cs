using System;

namespace TransactionPlatform.DomainLibrary.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; }
        public int UserId { get; set; }
        public DateTime BuyDT { get; set; }
        public decimal Price { get; set; }
        public int Volumen { get; set; }

        public decimal CurrentInstrumentValue()
        {
            //TODO: should call API for current Price
            return Price * Volumen;
        }

        public decimal CurrentProfitOnAsset()
        {
            //TODO: should call APi for current Price
            // return (CurrentPrice * Volumen) - (Price * Columen)
            return 0;
        }

        
    }
}
