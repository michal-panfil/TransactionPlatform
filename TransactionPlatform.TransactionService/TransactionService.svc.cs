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
	public class TransactionService : ITransactionService
	{
		public bool AcceptTransaction(TransactionFormDto transactionDto)
		{
			//PLAN:
			//1. Get instrument info frome API based on Ticker
			//2. Get Wallet infl from Api
			//3. Call Api and block amont on wallt
			//4. Add transaction to queue

			// Temprorary 4. call api and add Asset to wallet



			var api = new ApiCaller();

			try
			{
				//var instrument = api.GetInstrumentByTicker(transactionDto.Ticker);
				var charged = api.ChargeWallet(transactionDto);
				if (charged.Equals("True"))
				{
					var x = api.AddAssetToWallet(transactionDto);

				}

			}
			catch (Exception)
			{

				return false;
			}
			


			return true;
		}

		public List<InstrumentPriceDto> GetPriceOfAllInstruments()
		{
			var rnd = new Random();
			var priceList = new List<InstrumentPriceDto>();
			
			var api = new ApiCaller();
			var instruments = api.GetAllInstruments();

			foreach (var instrument in instruments)
			{
				priceList.Add(new InstrumentPriceDto { Id = instrument.Id, Price = (decimal)(rnd.Next(23,89)), Volumen = instrument.Id * 1500,  PriceDate = DateTime.UtcNow });
			}

			return priceList;
		}

			public List<InstrumentPriceDto> GetPriceOfAllInstrumentsAsync()
				{

					var priceList = new List<InstrumentPriceDto>();

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
