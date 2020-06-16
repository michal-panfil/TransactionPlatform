using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.TransactionService
{
    public class ApiCaller
    {
        public string BaseUri { get; set; } = $"http://localhost:54868/api/";
        public string SufixUri { get; set; }


        public List<Instrument> GetAllInstruments()
        {
            SufixUri = "Instrument";
            var apiRespone = CallApi().Result;

            var instruments = JsonConvert.DeserializeObject < List<Instrument>>(apiRespone);
            return instruments;
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