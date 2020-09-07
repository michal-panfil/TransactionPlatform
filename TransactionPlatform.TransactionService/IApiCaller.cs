using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;

namespace TransactionPlatform.TransactionService
{
    internal interface IApiCaller
    {
        string BaseUri { get; set; }

        string ChargeWallet(OrderForm transactionDto);
        Task<List<Instrument>> GetAllInstruments();
        Task<Instrument> GetInstrumentByTicker(string ticker);
        Task<Wallet> GetWalletByUserId(string userId);
        Task<string> MoveAsset(OrderForm transactionDto);
    }
}