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
        public string BaseUri { get; set; }


        public    Wallet GetWalletFromAPI(int userId)
        {
            // var reslut = CallApi(BaseUri)
            var apiTasks = CallApi();

              var x = apiTasks.GetAwaiter();
            return x.GetResult();
        }

        public async Task<Wallet> CallApi()
        {
            Wallet wallet;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:54868/api/UsersWallet?id=1")) {
                    var apiResonse = await response.Content.ReadAsStringAsync();
                     wallet = JsonConvert.DeserializeObject<Wallet>(apiResonse);
                } ;
            }
            return wallet;
        }
    }


}
