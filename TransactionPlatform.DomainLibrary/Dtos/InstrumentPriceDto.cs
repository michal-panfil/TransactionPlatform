using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Dtos
{
    public class InstrumentPriceDto
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public int? Volumen { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
