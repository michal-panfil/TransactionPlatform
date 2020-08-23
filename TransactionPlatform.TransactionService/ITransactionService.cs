using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        List<InstrumentPriceDto> GetPriceOfAllInstruments();

        [OperationContract]
        bool AcceptOrder(OrderForm orderDto);

        [OperationContract]
        Task<bool> CancellOrder(Guid operationId, string userId );
    

    }


    
}
