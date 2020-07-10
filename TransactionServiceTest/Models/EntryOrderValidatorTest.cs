using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.TransactionService.Models;

namespace TransactionServiceTest.Models
{
    [TestFixture]
    public class EntryOrderValidatorTest
    {

        [TestCaseSource(typeof(FormTestCases), "Complete")]
        public void CheckFormDatacompleteness_CorrectData_shouldSucces(TransactionFormDto form)
        {
            var result = EntryOrderValidator.CheckFormDataCompleteness(form);
            Assert.IsTrue(result, $"correct form was rejected : {form.Ticker}");
        }

        [TestCaseSource(typeof(FormTestCases), "Incomplete")]
        public void CheckFormDatacompleteness_IncorectData_shouldFailed(TransactionFormDto form)
        {
            var result = EntryOrderValidator.CheckFormDataCompleteness(form);
            Assert.IsFalse(result, $"Incorect form was accepted : {form.Ticker}");

        }
        
        [TestCaseSource(typeof(FormTestCases), "Correct")]
        public void CheckFormDataSemantic_Correct_Succes(TransactionFormDto form)
        {
            var result = EntryOrderValidator.CheckFormDataSemantic(form);
            Assert.IsTrue(result, $"correct form was rejected : {form.Ticker}");

        }

        [TestCaseSource(typeof(FormTestCases), "Incorect")]
        public void CheckFormDataSemantic_Incorect_Failed(TransactionFormDto form)
        {
            var result = EntryOrderValidator.CheckFormDataSemantic(form);
            Assert.IsFalse(result, $"Incorect form was accepted : {form.Ticker}");

        }
   
        [Test]
        [TestCase("t1")]
        public void ValidateWallet_EnoughCash_succes(string userId)
        {
            var result = EntryOrderValidator.ValidateWallet(userId);
            Assert.IsFalse(result);
        }
        [Test]
        [TestCase("t2")]
        public void ValidateWallet_NotEnaughCash_Failed(string userId)
        {
            var result = EntryOrderValidator.ValidateWallet(userId);
            Assert.IsTrue(result);
        }
    }
}
