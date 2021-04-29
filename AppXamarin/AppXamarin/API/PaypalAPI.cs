using AppXamarin.API.Interfaces;
using AppXamarin.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API
{
    class PaypalAPI : IPaypal
    {
        public void SendPay(double valAmount)
        {
            string messageError = string.Empty;
            string nameError = string.Empty;

            RequestPayModel requestPay = null;

            string linkPay = "https://api-m.sandbox.paypal.com/v1/payments/payouts";

            ServiceTokenModel serviceToken = GetToken();

            List<ItemsModel> listItems = new List<ItemsModel>();
            listItems.Add(new ItemsModel()
            {
                amount = new AmountModel()
                {
                    currency = "BRL",
                    value = valAmount.ToString()
                },
                note = "Payouts sample transaction",
                receiver = "sb-w47fx26025960@personal.example.com",
                recipient_type = "EMAIL",
                sender_item_id = "item-2-1619353250049"
            });

            requestPay = new RequestPayModel()
            {
                sender_batch_header = new BatchHeaderModel()
                {
                    email_subject = "You have a payment",
                    sender_batch_id = Guid.NewGuid().ToString()
                },
                items = listItems
            };

            var client = new RestClient(linkPay);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", serviceToken.access_token));

            var request = new RestRequest();
            request.AddJsonBody(requestPay);

            IRestResponse response = client.Post(request);

            var jObject = JObject.Parse(response.Content);

            if (jObject.ContainsKey("message"))
            {
                messageError = jObject.GetValue("message").ToString();
                nameError = jObject.GetValue("name").ToString();

                if (nameError.Contains("USER_BUSINESS_ERROR"))
                    throw new Exception("Something did not go very well. Try again later");
                else
                    throw new Exception(messageError);
            }
        }

        public ServiceTokenModel GetToken()
        {
            ServiceTokenModel serviceToken = new ServiceTokenModel();
            string linkGetToken = "https://api-m.sandbox.paypal.com/v1/oauth2/token";
            string clientID = "AYwqcEZUQTD1V7zcqg3wr57TOhADFqeReR-l-Ax3UTZA2j3fNCLprhyjP14XiLVimaZtGx5oDaZrhvbP";
            string secret = "ECXBAPj_hKreSGLKIk6BFEhZKzWY3P5ZHjbdS33dwNllHDlfCr7Qot0CFlk2W5vLRWWror1Y6-R7DqCi";

            var client = new RestClient(linkGetToken);
            client.Authenticator = new HttpBasicAuthenticator(clientID, secret);

            var request = new RestRequest();
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");

            IRestResponse response = client.Post(request);

            var jObject = JObject.Parse(response.Content);

            if (jObject.ContainsKey("access_token"))
            {
                serviceToken.access_token = jObject.GetValue("access_token").ToString();
            }

            if (string.IsNullOrEmpty(serviceToken.access_token))
                throw new Exception("Could not perform authentication. Try again.");

            return serviceToken;
        }
    }
}
