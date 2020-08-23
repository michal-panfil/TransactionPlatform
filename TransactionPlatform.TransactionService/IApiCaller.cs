using System.Collections.Generic;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.TransactionService
{
    internal interface IApiCaller
    {
        string BaseUri { get; set; }

        string ChargeWallet(OrderForm transactionDto);
        List<Instrument> GetAllInstruments();
        Instrument GetInstrumentByTicker(string ticker);
        Wallet GetWalletByUserId(string userId);
        string MoveAsset(OrderForm transactionDto);
    }
}