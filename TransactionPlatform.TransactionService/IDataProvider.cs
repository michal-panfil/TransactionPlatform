using System.Collections.Generic;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.TransactionService
{
    public interface IDataProvider
    {
         Wallet GetWalletByUserId(string userId);
        List<Instrument> GetAllInstruments();
        string ChargeWallet(TransactionFormDto transactionDto);
        string MoveAsset(TransactionFormDto transactionDto);
        Instrument GetInstrumentByTicker(string ticker);
    }
}