using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService.DAL;
using TransactionPlatform.TransactionService.Models;

namespace TransactionPlatform.TransactionService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class TransactionService : ITransactionService
	{
        public MongoContext DB { get; set; }
        public TransactionService()
		{
			
				var processor = OrderProccessor.Instance;
			
		}
		public void DoSomething()
        {
			var x = 5;

		}
		public bool AcceptTransaction(OrderFormDto transactionDto)
		{
			var orderAccepted = false;

			var order = new Order
			{
				Id = new Guid(),
				OrderForm = transactionDto,
				ReceivedDT = DateTime.UtcNow,
				Status = OrderStatus.New,
			};
			DB.AddOrderToDb(order);

			var orderIsValid = ValidateOrder(order);

			if (orderIsValid)
			{
				orderAccepted = EntryQueue.AddToQueue(order);
			}
			

			return orderAccepted;
		}

		private bool ValidateOrder(Order order)
		{
			var isValid = false;
            if (EntryOrderValidator.CheckFormDataCompleteness(order.OrderForm))
            {
                if (EntryOrderValidator.CheckFormDataSemantic(order.OrderForm))
                {
					var wallet = new ApiCaller().GetWalletByUserId(order.OrderForm.UserId);
					if (EntryOrderValidator.ValidateWallet(order.OrderForm, wallet))
                    {
						isValid = true;
                    }
                }
            }

			return isValid;
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
