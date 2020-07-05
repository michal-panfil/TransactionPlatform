using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionService
    {


        [OperationContract]
        float GetPriceOfInstrument(int id);

        [OperationContract]
        List<InstrumentPriceDto> GetPriceOfAllInstruments();

        [OperationContract]
        bool AcceptTransaction(TransactionFormDto transactionDto);

    }


    
}
