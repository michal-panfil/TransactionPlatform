using System;
using System.Collections;
using TransactionPlatform.DomainLibrary.Dtos;

namespace TransactionServiceTest.Models
{
    public class FormTestCases
    {
        public static IEnumerable Complete
        {
            get
            {
                yield return new TransactionFormDto("Ticker", 12.3f, 100, "userId", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("Ticker", 12.3f, 100, "userId", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("sd", 50000f, 100, "userId", DateTime.UtcNow, TransactionType.Sell);
                yield return new TransactionFormDto("Ticasdasasdasdassadsaker", 89.3453f, 100, "userIasdasdsaddasasdd", DateTime.Now, TransactionType.Sell);
                yield return new TransactionFormDto("Ticker", 12f, 100, "userId", DateTime.Now, TransactionType.Buy);

            }
        }
        
        public static IEnumerable Incomplete
        {
            get
            {
                yield return new TransactionFormDto("", 12.3f, 100, "userId", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("Ticker", 12.3f, 100, "", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("sd", 0, 100, "userId", DateTime.UtcNow, TransactionType.Sell);
                yield return new TransactionFormDto("Ticasdasasdasdassadsaker", 89.3453f, 0, "userIasdasdsaddasasdd", DateTime.Now, TransactionType.Sell);
                yield return new TransactionFormDto("Ticker", 12f, 100, "userId", DateTime.Now, TransactionType.Undefined);

            }
        }
        public static IEnumerable Correct
        {
            get
            {
                yield return new TransactionFormDto("t1", 12.3f, 100, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t2", 0.1f, 1,  "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t3", 50000.0000f, 50000, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
            }
        }
        public static IEnumerable Incorect
        {
            get
            {
                yield return new TransactionFormDto("t1", 12.3f, 100, "0f8fadb-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t2", 0.0f, 1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t3", -0.1f, 1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t4", -0.1f, 1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t5", 50001.0000f, 500000, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t6", 50001.0000f, 0, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t7", 50001.0000f, -1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, TransactionType.Buy);
                yield return new TransactionFormDto("t8", 50001.0000f, 500001, "0f8fad5b-d9cb-469f-a165-70867728950e", (DateTime.Now.AddDays(-2)), TransactionType.Buy);
                yield return new TransactionFormDto("t9", 50001.0000f, 5000 , "0f8fad5b-d9cb-469f-a165-70867728950e", (DateTime.Now.AddDays(1)), TransactionType.Buy);
                yield return new TransactionFormDto("t10", 50001.0000f, 5000 , "0f8fad5b-d9cb-469f-a165-70867728950e", (DateTime.Now.AddDays(-2)), TransactionType.Buy);

            }
        }


    }
}
