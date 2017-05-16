using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayJunction.Responses
{
    public class Match
    {
        public bool Zip { get; set; }
        public bool Address { get; set; }
    }

    public class Avs
    {
        public string Status { get; set; }
        public string Requested { get; set; }
        public Match Match { get; set; }
    }

    public class Cvv
    {
        public string Status { get; set; }
    }

    public class Processor
    {
        public bool Authorized { get; set; }
        public string ApprovalCode { get; set; }
        public Avs Avs { get; set; }
        public Cvv Cvv { get; set; }
    }

    public class Response
    {
        public bool Approved { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public Processor Processor { get; set; }
    }

    public class Settlement
    {
        public bool Settled { get; set; }
    }

    public class Vault
    {
        public string Type { get; set; }
        public string AccountType { get; set; }
        public string LastFour { get; set; }
    }

    public class Address
    {
        [JsonProperty(PropertyName = "address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }

    public class Billing
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string companyName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Phone2 { get; set; }
        public string JobTitle { get; set; }
        public string Identifier { get; set; }
        public string Website { get; set; }
        public Address Address { get; set; }
    }

    public class Shipping
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string JobTitle { get; set; }
        public string Identifier { get; set; }
        public string Website { get; set; }
        public Address address { get; set; }
    }

    public class ResponseObject
    {
        [JsonProperty(PropertyName = "errors")]
        public string[] Errors { get; set; }
        public string Help { get; set; }

        [JsonIgnore]
        public bool IsSuccessful
        {
            get
            {
                return Errors == null || Errors.Length <= 0;
            }
        }

        public int TransactionId { get; set; }
        public string Uri { get; set; }
        public int TerminalId { get; set; }
        public string Action { get; set; }
        public string AmountBase { get; set; }
        public string AmountTax { get; set; }
        public string AmountShipping { get; set; }
        public string AmountTip { get; set; }
        public string AmountSurcharge { get; set; }
        public string AmountTotal { get; set; }
        public string InvoiceNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string SignatureStatus { get; set; }
        public string Status { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public Response Response { get; set; }
        public Settlement Settlement { get; set; }
        public Vault Vault { get; set; }
        public Billing Billing { get; set; }
        public Shipping Shipping { get; set; }
    }
}
