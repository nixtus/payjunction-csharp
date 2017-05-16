using System;
using NUnit.Framework;
using PayJunction.Requests;

namespace PayJunction.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private string _apiTestLogin = "pj-ql-01";
        private string _apiTestPassword = "pj-ql-01p";

        [Test]
        public void TestMethod1()
        {
            var client = new PayJunctionClient(_apiTestLogin, _apiTestPassword, "", true);

            var response = client.ChargeAndCapture(new TransactionFields
            {
                Action = "CHARGE",
                AmountBase = 2.00M,
                CreditCard = new CreditCard
                {
                    CardNumber = "4444333322221111",
                    CardExpMonth = "01",
                    CardExpYear = "20"
                }
            });
        }
    }
}
