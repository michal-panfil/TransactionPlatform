using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWalletController : ControllerBase
    {
        [HttpGet]
        public Wallet Get(int id)
        {
            var assets = new List<AssetDto>
            {
                new AssetDto{ Id = 1, Ticker = "OB3", Name="Oli Brand 3" , InitialPrice =27M, Volumen = 500},
                new AssetDto{ Id = 1, Ticker = "API", Name="Avreage Price Contract" , InitialPrice =721M, Volumen = 77},
                new AssetDto{ Id = 1, Ticker = "WTF", Name="World Train Federation" , InitialPrice =2.63M, Volumen = 2500}
            };

            // have to create WalletDto
            var wallet = new Wallet()
            {
                Id = 1,
                OwnerId = 1,
                Cash = 15324M,
                Assets = assets,
                SumInvestedMoney = 70345M
            };


            return wallet;
        }

    }
}