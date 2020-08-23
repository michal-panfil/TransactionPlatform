using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models.WalletModels;
using TransactionPlatform.TransactionService.Models;

namespace TransactionServiceTest.Models
{
    [TestFixture]
    public class EntryOrderValidatorTest
    {

        [TestCaseSource(typeof(FormTestCases), "Complete")]
        public void CheckFormDatacompleteness_CorrectData_shouldSucces(OrderForm form)
        {
            var result = EntryOrderValidator.CheckFormDataCompleteness(form);
            Assert.IsTrue(result, $"correct form was rejected : {form.Ticker}");
        }

        [TestCaseSource(typeof(FormTestCases), "Incomplete")]
        public void CheckFormDatacompleteness_IncorectData_shouldFailed(OrderForm form)
        {
            var result = EntryOrderValidator.CheckFormDataCompleteness(form);
            Assert.IsFalse(result, $"Incorect form was accepted : {form.Ticker}");

        }
        
        [TestCaseSource(typeof(FormTestCases), "Correct")]
        public void CheckFormDataSemantic_Correct_Succes(OrderForm form)
        {
            var result = EntryOrderValidator.CheckFormDataSemantic(form);
            Assert.IsTrue(result, $"correct form was rejected : {form.Ticker}");

        }

        [TestCaseSource(typeof(FormTestCases), "Incorect")]
        public void CheckFormDataSemantic_Incorect_Failed(OrderForm form)
        {
            var result = EntryOrderValidator.CheckFormDataSemantic(form);
            Assert.IsFalse(result, $"Incorect form was accepted : {form.Ticker}");

        }
   
        [Test]
        public void ValidateWallet_BuyEnoughCash_succes()
        {
            var form = new OrderForm() { Price = 100f, Volumen = 100, OrderType = OrderType.Buy };
            var wallet = new Wallet() { CirculatingMedium = new Cash() { AvailableAmount = 10001M } };

            var result = EntryOrderValidator.ValidateWallet(form, wallet);
            Assert.IsTrue(result);
        }
        [Test]
        public void ValidateWallet_BuyExactliCash_succes()
        {
            var form = new OrderForm() { Price = 100f, Volumen = 100, OrderType = OrderType.Buy };
            var wallet = new Wallet() { CirculatingMedium = new Cash() { AvailableAmount = 10000M } };

            var result = EntryOrderValidator.ValidateWallet(form, wallet);
            Assert.IsTrue(result);
        }
        [Test]
        public void ValidateWallet_BuyNotEnaughCash_Failed()
        {
            var form = new OrderForm() { Price = 100f, Volumen = 100, OrderType = OrderType.Buy };
            var wallet = new Wallet() { CirculatingMedium = new Cash() { AvailableAmount = 999M } };

            var result = EntryOrderValidator.ValidateWallet(form, wallet);
            Assert.IsFalse(result);
        }
        [Test]
        public void ValidateWallet_SellHasInstrument_succes()
        {
            var form = new OrderForm() {Ticker = "test", Volumen = 100, OrderType = OrderType.Sell };
            var wallet = new Wallet() { Assets = new List<BaseAsset>() { new BaseAsset() { Name = "test", Volumen = 100 } } };
            var result = EntryOrderValidator.ValidateWallet(form, wallet);
            Assert.IsTrue(result);
        }
        [Test]
        public void ValidateWallet_SellHasSomeInstrument_Failed()
        {
            var form = new OrderForm() { Ticker = "test", Volumen = 100, OrderType = OrderType.Sell };
            var wallet = new Wallet() { Assets = new List<BaseAsset>() { new BaseAsset() { Name = "test", Volumen = 99 } } };
            var result = EntryOrderValidator.ValidateWallet(form, wallet);
            Assert.IsFalse(result);

        }
        [Test]
        public void ValidateWallet_SellHasNotInstrument_Failed()
        {
            var form = new OrderForm() { Ticker = "test", Volumen = 100, OrderType = OrderType.Sell };
            var wallet = new Wallet() { Assets = new List<BaseAsset>() {  } };
            var result = EntryOrderValidator.ValidateWallet(form, wallet);
            Assert.IsFalse(result);

        }
    }
}
