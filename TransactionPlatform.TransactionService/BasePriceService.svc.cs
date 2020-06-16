using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.TransactionService
{
	public class BasePriceService : IBasePriceService
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

			foreach(var instrument in instruments)
			{
				priceList.Add(new InstrumentPriceDto { Id = instrument.Id, Price = instrument.Id + 100, PriceDate = DateTime.UtcNow });
			}

			return priceList;
		}

		public float GetPriceOfInstrument(int id)
		{
			//checking connection with WCF

			return id * 10f;
		}
	}
}