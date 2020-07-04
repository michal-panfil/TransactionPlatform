using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService;

namespace WCFServiceTest.TransactionService
{
    [TestFixture]
    public class ApiCallerTest
    {
        [Test]
        public void ChargeWalletTest()
        {
            var apiCaller = new ApiCaller();
            var transDto = new TransactionFormDto
            {
                Ticker = "o4",
                Price = 100,
                Volumen = 100,
                UserId = "tets",
                TransactionTime = DateTime.Now,
                TransType = TransactionType.Sell
            };
            apiCaller.ChargeWallet(transDto);

        }


    }
}
