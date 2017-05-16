using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayJunction.Requests
{
    public class TransactionFields
    {
        public string Status { get; set; }
        public string TerminalId { get; set; }
        public string Action { get; set; }
        public decimal AmountBase { get; set; }
        public decimal AmountShipping { get; set; }
        public decimal AmountTip { get; set; }
        public decimal AmountReject { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountSurcharge { get; set; }
        public CreditCard CreditCard { get; set; }
        public BillingContact BillingContact { get; set; }
        public TransactionFields()
        {
            CreditCard = new CreditCard();
            BillingContact = new BillingContact();
        }

    }
}
