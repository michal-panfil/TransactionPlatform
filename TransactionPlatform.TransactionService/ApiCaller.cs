using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.TransactionService
{
    internal class ApiCaller :IDataProvider
    {
        public string BaseUri { get; set; } = $"http://localhost:54868/api/";


        public Wallet GetWalletByUserId(string userId)
        {
            var sufixUri = @"UsersWallet/GetWallet/{" + userId + "}";
            var apiResponse = CallApiGet(sufixUri).Result;

            var wallet = JsonConvert.DeserializeObject<Wallet>(apiResponse);
            return wallet;
        }
        public List<Instrument> GetAllInstruments()
        {
            var sufixUri = "Instrument/GetInstruments";
            var apiResponse = CallApiGet(sufixUri).Result;

            var instruments = JsonConvert.DeserializeObject < List<Instrument>>(apiResponse);
            return instruments;
        }


        public string ChargeWallet(OrderFormDto transactionDto)
        {
            var sufixUri = @"UsersWallet/ChargeCreditWallt";
            var json = new JsonTextWriter(new StringWriter(new StringBuilder()));
            var textW = new StringWriter(new StringBuilder());
            var jsonSerrializer = new JsonSerializer();

            var transactionPrice = transactionDto.OrderType == OrderType.Buy ? transactionDto.Price * transactionDto.Volumen : transactionDto.Price * transactionDto.Volumen * (-1);

            var transactionData = new ChargeWalletDto{ UserId = transactionDto.UserId, Amount = (decimal)transactionPrice };


            jsonSerrializer.Serialize(textW, transactionData);

            var content = new StringContent(textW.ToString(), Encoding.UTF8, "application/json");

            var response =  CallApiPost(sufixUri, content).Result;

            return response;

        }

        public string MoveAsset(OrderFormDto transactionDto)
        {
            var sufixUri = transactionDto.OrderType == OrderType.Buy ?  @"UsersWallet/AddAssetToWallet" : @"UsersWallet/RemoveAssetFromWallet";
        
            var json = new JsonTextWriter(new StringWriter(new StringBuilder()));
            var textW = new StringWriter(new StringBuilder());
            var x = new JsonSerializer();
            x.Serialize(textW, transactionDto);

            var content = new StringContent(textW.ToString(), Encoding.UTF8, "application/json");


            var response = CallApiPost(sufixUri, content).Result;


            return response; 
        }

        public Instrument GetInstrumentByTicker(string ticker)
        {
            var sufixUri = @"Instrument/{" + ticker + "}";
            var apiResponse = CallApiGet(sufixUri).Result;
            var instrument = JsonConvert.DeserializeObject<Instrument>(apiResponse);
            return instrument;
        }
        private async Task<string> CallApiGet( string sufixUri)
        {
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(BaseUri + sufixUri))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        } 
        private async Task<string> CallApiPost(string sufixUri, HttpContent contnet)
        {
            string result;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(BaseUri + sufixUri, contnet))
                {
                    result = await response.Content.ReadAsStringAsync();
                };
            }
            return result;
        }
    }
}