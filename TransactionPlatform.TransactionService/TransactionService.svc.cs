using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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
        public static IDBContext DB { get; set; }
        
        public static void Configure(ServiceConfiguration configuration)
        {
            DB = OrderProccessor.Instance.DB;
            Task.Factory.StartNew(() => OrderProccesorScheduler.Instance.Schedule());

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs\\TransactionService\\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }


        public async Task<bool> AcceptOrder(OrderForm orderForm)
        {
            try
            {
                Log.Information($"Received order {orderForm.Id}, from {orderForm.UserId}, operation : {orderForm.OrderType.ToString()}, {orderForm.Ticker}, {orderForm.Price}, {orderForm.Volumen}");
                
                var orderAccepted = false;

                var order = new Order
                {
                    Id = new Guid(),
                    OrderForm = orderForm,
                    ReceivedDT = DateTime.UtcNow,
                    Status = OrderStatus.New,
                };

                var orderIsValid = await ValidateOrderForm(orderForm);

                if ( orderIsValid)
                {
                    order.IsValid = orderIsValid;
                    orderAccepted = EntryQueue.AddToQueue(order);
                }
                else
                {
                    Log.Warning($"Order {orderForm.Id} is not valid");
                }

               await DB.AddOrderToDb(order);

                return orderAccepted;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
       
        }



        private async Task<bool> ValidateOrderForm(OrderForm orderForm)
        {
            var isValid = false;
            if (EntryOrderValidator.CheckFormDataCompleteness(orderForm))
            {
                if (EntryOrderValidator.CheckFormDataSemantic(orderForm))
                {
                    var wallet = await new ApiCaller().GetWalletByUserId(orderForm.UserId);
                    
                    if (wallet is null) return false;

                    if (EntryOrderValidator.ValidateWallet(orderForm, wallet))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

        //TODO: It is only pleaceholder
        public async Task<List<InstrumentPriceDto>> GetPriceOfAllInstruments()
        {
            var rnd = new Random();
            var priceList = new List<InstrumentPriceDto>();

            var api = new ApiCaller();
            var instruments = await api.GetAllInstruments();

            foreach (var instrument in instruments)
            {
                priceList.Add(new InstrumentPriceDto { Id = instrument.Id, Price = (decimal)(rnd.Next(23, 89)), Volumen = instrument.Id * 1500, PriceDate = DateTime.UtcNow });
            }

            return priceList;
        }
        //TODO: It is only pleaceholder

        public async  Task<List<InstrumentPriceDto>> GetPriceOfAllInstrumentsAsync()
        {

            var priceList = new List<InstrumentPriceDto>();

            var api = new ApiCaller();
            var instruments = await api.GetAllInstruments();

            foreach (var instrument in instruments)
            {
                priceList.Add(new InstrumentPriceDto { Id = instrument.Id, Price = instrument.Id + 100, PriceDate = DateTime.UtcNow });
            }

            return priceList;
        }

        public async Task<bool> CancellOrder(Guid orderFromId, string userId)
        {
            var order = await DB.GetOrderByOrderFormId(orderFromId);
            if (order == null || order.Status == OrderStatus.Accepted || order.Status == OrderStatus.Done)
            {
                return false;
            }
            var update = await DB.ChangeStatus(order, OrderStatus.Cancelled);
            OrderProccessor.StopProccesingOrder(order.Id);
            return update.MatchedCount == 1 ? true : false;

        }

        //Demo mode creates oposit order that transacion effects are visible right away for user
        private Order CreateOppositDummyOrder(OrderForm orderForm)
        {
            var orderType = orderForm.OrderType == OrderType.Buy ? OrderType.Sell : OrderType.Buy;
            var oppositForm = new OrderForm(orderForm.Ticker, orderForm.Price, orderForm.Volumen, "00000000-0000-0000-0000-000000000000", DateTime.Now, orderType);

            var order = new Order
            {
                Id = new Guid(),
                OrderForm = oppositForm,
                ReceivedDT = DateTime.UtcNow,
                Status = OrderStatus.New,
            };
            return order;
        }
    }
}
