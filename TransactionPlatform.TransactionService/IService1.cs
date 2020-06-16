﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        float GetPriceOfInstrument(int id);

        [OperationContract]
        List<InstrumentPriceDto> GetPriceOfAllInstruments();
        // TODO: Add your service operations here
        [OperationContract]
        List<InstrumentPriceDto> GetPriceOfAllInstrumentsAsync();
    }


    
}
