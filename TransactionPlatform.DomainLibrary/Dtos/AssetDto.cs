using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Dtos
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public int Volumen { get; set; }
        public decimal InitialPrice { get; set; }
    }
}
