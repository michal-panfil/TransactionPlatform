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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<InstrumentPriceDto> GetPriceOfAllInstruments()
        {

            var priceList = new List<InstrumentPriceDto>();
            /*
			 * 1. call API to get List of Instruments
			 * 2. generate price for each one by random method
			 * 
			 */
            var api = new ApiCaller();
            var instruments = api.GetAllInstruments();

            foreach (var instrument in instruments)
            {
                priceList.Add(new InstrumentPriceDto { Id = instrument.Id, Price = instrument.Id + 100, PriceDate = DateTime.UtcNow });
            }

            return priceList;
        }

        public List<InstrumentPriceDto> GetPriceOfAllInstrumentsAsync()
        {

            var priceList = new List<InstrumentPriceDto>();
            /*
			 * 1. call API to get List of Instruments
			 * 2. generate price for each one by random method
			 * 
			 */
            var api = new ApiCaller();
            var instruments = api.GetAllInstruments();

            foreach (var instrument in instruments)
            {
                priceList.Add(new InstrumentPriceDto { Id = instrument.Id, Price = instrument.Id + 100, PriceDate = DateTime.UtcNow });
            }

            return priceList;
        }

        public float GetPriceOfInstrument(int id)
        {
            return id * 1.5f;
        }
    }
}
