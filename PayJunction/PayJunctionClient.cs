using Newtonsoft.Json;
using PayJunction.Requests;
using PayJunction.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PayJunction
{
    public class PayJunctionClient
    {
        private string _apiLogin;
        private string _apiPassword;
        private string _apiKey;
        private bool _testMode;

        private string _sandboxUrl = "https://api.payjunctionlabs.com/transactions";
        private string _prodUrl = "https://api.payjunction.com/transactions";

        public PayJunctionClient(string apiLogin, string apiPassword, string apiKey, bool testMode = false)
        {
            _apiLogin = apiLogin;
            _apiPassword = apiPassword;
            _apiKey = apiKey;
            _testMode = testMode;
        }

        public ResponseObject ChargeAndCapture(TransactionFields request)
        {
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(Constants.Status, request.Status),
                new KeyValuePair<string, string>(Constants.TerminalId, request.TerminalId),
                new KeyValuePair<string, string>(Constants.Action, request.Action),
                new KeyValuePair<string, string>(Constants.AmountBase, request.AmountBase.ToString()),
                new KeyValuePair<string, string>(Constants.AmountShipping, request.AmountShipping.ToString()),
                new KeyValuePair<string, string>(Constants.AmountTip, request.AmountTip.ToString()),
                new KeyValuePair<string, string>(Constants.AmountReject, request.AmountReject.ToString()),
                new KeyValuePair<string, string>(Constants.AmountSurcharge, request.AmountSurcharge.ToString()),
                new KeyValuePair<string, string>(Constants.BillingIdentifier, request.BillingContact.BillingIdentifier),
                new KeyValuePair<string, string>(Constants.BillingFirstName, request.BillingContact.BillingFirstName),
                new KeyValuePair<string, string>(Constants.BillingMiddleName, request.BillingContact.BillingMiddleName),
                new KeyValuePair<string, string>(Constants.BillingLastName, request.BillingContact.BillingLastName),
                new KeyValuePair<string, string>(Constants.BillingCompanyName, request.BillingContact.BillingCompanyName),
                new KeyValuePair<string, string>(Constants.BillingJobTitle, request.BillingContact.BillingJobTitle),
                new KeyValuePair<string, string>(Constants.BillingPhone, request.BillingContact.BillingPhone),
                new KeyValuePair<string, string>(Constants.BillingPhone2, request.BillingContact.BillingPhone2),
                new KeyValuePair<string, string>(Constants.BillingAddress, request.BillingContact.BillingAddress),
                new KeyValuePair<string, string>(Constants.BillingCity, request.BillingContact.BillingCity),
                new KeyValuePair<string, string>(Constants.BillingState, request.BillingContact.BillingState),
                new KeyValuePair<string, string>(Constants.BillingZip, request.BillingContact.BillingZip),
                new KeyValuePair<string, string>(Constants.BillingCountry, request.BillingContact.BillingCountry),
                new KeyValuePair<string, string>(Constants.BillingEmail, request.BillingContact.BillingEmail),
                new KeyValuePair<string, string>(Constants.BillingWebsite, request.BillingContact.BillingWebsite),
                new KeyValuePair<string, string>(Constants.CardNumber, request.CreditCard.CardNumber),
                new KeyValuePair<string, string>(Constants.CardExpMonth, request.CreditCard.CardExpMonth),
                new KeyValuePair<string, string>(Constants.CardExpYear, request.CreditCard.CardExpYear),
                new KeyValuePair<string, string>(Constants.CardCvv, request.CreditCard.CardCvv),
            };

            var content = FormatRequestParameters(requestParams);
            return Execute(content);
        }

        private ResponseObject Execute(FormUrlEncodedContent request)
        {
            var responseObj = new ResponseObject();

            using (var client = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                client.DefaultRequestHeaders.Authorization = CreateAuthorizationHeader();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-PJ-Application-Key", _apiKey);

                var response = client.PostAsync(_testMode ? _sandboxUrl : _prodUrl, request).Result;

                if (response.IsSuccessStatusCode)
                {
                    responseObj = JsonConvert.DeserializeObject<ResponseObject>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    
                }
            }

            return responseObj;
        }

        private FormUrlEncodedContent FormatRequestParameters(IList<KeyValuePair<string, string>> requestParams)
        {
            var finalParams = requestParams.Where(x => !string.IsNullOrEmpty(x.Value));

            var content = new FormUrlEncodedContent(finalParams);
            return content;
        }

        private AuthenticationHeaderValue CreateAuthorizationHeader()
        {
            var encodedHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_apiLogin}:{_apiPassword}"));
            return new AuthenticationHeaderValue("Basic", encodedHeader);
        }
    }
}
