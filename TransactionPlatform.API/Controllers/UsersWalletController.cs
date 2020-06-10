using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWalletController : ControllerBase
    {
        [HttpGet]
        public Wallet Get(int id)
        {
            var assets = new List<Asset>
            {
                new Asset{ Id = 1, InstrumentId = 1, UserId = 1, BuyDT = DateTime.Today, Price =27M, Volumen = 500},
                new Asset{ Id = 1, InstrumentId = 1, UserId = 1, BuyDT = DateTime.Today, Price =27M, Volumen = 500}
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