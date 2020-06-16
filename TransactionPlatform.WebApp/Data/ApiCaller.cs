using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public class ApiCaller
    {
        public string BaseUri { get; set; } = $"http://localhost:54868/api/";
        public string SufixUri { get; set; } 

       

        public async Task<string> CallApi()
        {
            string result;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUri + SufixUri)) {
                     result = await response.Content.ReadAsStringAsync();
                } ;
            }
            return result;
        }
        public async Task<List<Instrument>> GetInstrumentsFromAPI()
        {
            SufixUri = $"Instrument";

            var apiTasks = CallApi();
            var apiResponse = await apiTasks;
            var instruments = JsonConvert.DeserializeObject<List<Instrument>>(apiResponse);

            return instruments;
        }

        public async Task<Wallet> GetWalletFromAPI(int userId)
        {
            SufixUri = $"UsersWallet?id={userId}";

            var apiTasks = CallApi();
            var apiResponse = await apiTasks;
            var wallet = JsonConvert.DeserializeObject<Wallet>(apiResponse);

            return wallet;
        }
    }


}
