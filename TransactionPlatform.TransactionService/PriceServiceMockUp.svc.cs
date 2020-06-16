using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.TransactionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PriceServiceMockUp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PriceServiceMockUp.svc or PriceServiceMockUp.svc.cs at the Solution Explorer and start debugging.
    public class PriceServiceMockUp : IPriceServiceMockUp
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
	}
}
