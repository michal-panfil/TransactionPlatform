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
    public class ApiCaller
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

        internal string ChargeWallet(TransactionFormDto transactionDto)
        {
            var sufixUri = @"UsersWallet/ChargeWallet";
            var json = new JsonTextWriter(new StringWriter(new StringBuilder()));
            var textW = new StringWriter(new StringBuilder());
            var x = new JsonSerializer();
            x.Serialize(textW, transactionDto);

            var content = new StringContent(textW.ToString(), Encoding.UTF8, "application/json");


            var response =  CallApiPost(sufixUri, content).Result;
            

            return response;
            
            //


        }

        internal object AddAssetToWallet(TransactionFormDto transactionDto)
        {
            var sufixUri = @"UsersWallet/AddAssetToWallet";
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