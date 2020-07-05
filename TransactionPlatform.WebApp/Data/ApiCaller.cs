using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.WebApp.Data
{
    public class ApiCaller
    {
        public string BaseUri { get; set; } = $"http://localhost:54868/api/";
 
        private async Task<string> CallApiGet(string sufix)
        {
            string result;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUri + sufix)) {
                     result = await response.Content.ReadAsStringAsync();
                } ;
            }
            return result;
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
        public async Task<List<Instrument>> GetInstrumentsFromAPI()
        {
          
            var sufixUri = $"Instrument/GetInstruments";

            var apiTasks = CallApiGet(sufixUri);
            var apiResponse = await apiTasks;
            var instruments = JsonConvert.DeserializeObject<List<Instrument>>(apiResponse);

            return instruments;
        }
         
        public async Task<Wallet> GetWalletFromAPI(string userId)
        {
            //SufixUri = $"UsersWallet/GetWallet?Id=" + userId;
            var sufixUri = $"UsersWallet/GetWallet?Id=" + userId;


            var apiTasks = CallApiGet(sufixUri);
            var apiResponse = await apiTasks;
            var settings = new JsonSerializerSettings
            {
                MaxDepth = 99,
                ReferenceLoopHandling = ReferenceLoopHandling.Error
            };
            var wallet = JsonConvert.DeserializeObject<Wallet>(apiResponse, settings);

            return wallet;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            var sufixUri = $"UsersWallet/AddWallet";
            var json = new JsonTextWriter(new StringWriter(new StringBuilder()));
            var textW = new StringWriter(new StringBuilder());
            var x = new JsonSerializer();
            x.Serialize(textW, wallet);

            var content = new StringContent(textW.ToString(), Encoding.UTF8, "application/json");


            var apiTasks = CallApiPost(sufixUri, content);
            var apiResponse = await apiTasks;
            var resultWallet = JsonConvert.DeserializeObject<Wallet>(apiResponse);

            return resultWallet;
        }
    }
}
