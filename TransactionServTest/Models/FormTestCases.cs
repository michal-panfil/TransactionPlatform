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
                yield return new OrderForm("Ticker", 12.3f, 100, "userId", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("Ticker", 12.3f, 100, "userId", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("sd", 50000f, 100, "userId", DateTime.UtcNow, OrderType.Sell);
                yield return new OrderForm("Ticasdasasdasdassadsaker", 89.3453f, 100, "userIasdasdsaddasasdd", DateTime.Now, OrderType.Sell);
                yield return new OrderForm("Ticker", 12f, 100, "userId", DateTime.Now, OrderType.Buy);

            }
        }
        
        public static IEnumerable Incomplete
        {
            get
            {
                yield return new OrderForm("", 12.3f, 100, "userId", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("Ticker", 12.3f, 100, "", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("sd", 0, 100, "userId", DateTime.UtcNow, OrderType.Sell);
                yield return new OrderForm("Ticasdasasdasdassadsaker", 89.3453f, 0, "userIasdasdsaddasasdd", DateTime.Now, OrderType.Sell);
                yield return new OrderForm("Ticker", 12f, 100, "userId", DateTime.Now, OrderType.Undefined);

            }
        }
        public static IEnumerable Correct
        {
            get
            {
                yield return new OrderForm("t1", 12.3f, 100, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t2", 0.1f, 1,  "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t3", 50000.0000f, 50000, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
            }
        }
        public static IEnumerable Incorect
        {
            get
            {
                yield return new OrderForm("t1", 12.3f, 100, "0f8fadb-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t2", 0.0f, 1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t3", -0.1f, 1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t4", -0.1f, 1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t5", 50001.0000f, 500000, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t6", 50001.0000f, 0, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t7", 50001.0000f, -1, "0f8fad5b-d9cb-469f-a165-70867728950e", DateTime.Now, OrderType.Buy);
                yield return new OrderForm("t8", 50001.0000f, 500001, "0f8fad5b-d9cb-469f-a165-70867728950e", (DateTime.Now.AddDays(-2)), OrderType.Buy);
                yield return new OrderForm("t9", 50001.0000f, 5000 , "0f8fad5b-d9cb-469f-a165-70867728950e", (DateTime.Now.AddDays(1)), OrderType.Buy);
                yield return new OrderForm("t10", 50001.0000f, 5000 , "0f8fad5b-d9cb-469f-a165-70867728950e", (DateTime.Now.AddDays(-2)), OrderType.Buy);

            }
        }


    }
}
