using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public string SufixUri { get; set; }


        public Wallet GetWalletByUserId(string userId)
        {
            SufixUri = @"UsersWallet/GetWallet/{" + userId + "}";
            var apiResponse = CallApi().Result;

            var wallet = JsonConvert.DeserializeObject<Wallet>(apiResponse);
            return wallet;
        }
        public List<Instrument> GetAllInstruments()
        {
            SufixUri = "Instrument/GetInstruments";
            var apiResponse = CallApi().Result;

            var instruments = JsonConvert.DeserializeObject < List<Instrument>>(apiResponse);
            return instruments;
        }

        internal object ChargeWallet(TransactionFormDto transactionDto)
        {
            throw new NotImplementedException();
        }

        internal object AddAssetToWallet(TransactionFormDto transactionDto)
        {
            throw new NotImplementedException();
        }

        public Instrument GetInstrumentByTicker(string ticker)
        {
            SufixUri = @"Instrument/{" + ticker + "}";
            var apiResponse = CallApi().Result;
            var instrument = JsonConvert.DeserializeObject<Instrument>(apiResponse);
            return instrument;
        }
        private async Task<string> CallApi()
        {
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(BaseUri + SufixUri))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}