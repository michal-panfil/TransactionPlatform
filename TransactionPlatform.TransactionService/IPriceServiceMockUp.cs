using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPriceServiceMockUp" in both code and config file together.
    [ServiceContract]
    public interface IPriceServiceMockUp
    {
        [OperationContract]
        List<InstrumentPriceDto> GetPriceOfAllInstruments();      
        [OperationContract]
        List<InstrumentPriceDto> GetPriceOfAllInstrumentsAsync();
    }
}
