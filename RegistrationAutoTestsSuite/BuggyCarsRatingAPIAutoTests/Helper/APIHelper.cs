using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace BuggyCarsRatingAPIAutoTests.Helper
{
    public class APIHelper
    {
        private RestClient _client;

         /// <summary>
        /// API Client with authentication
        /// </summary>
        public RestClient APIClient
        {
            get
            {
                _client = new RestClient(BaseURL);
                return _client;
            }
            set
            {
                _client = value;
            }
        }
        public APIHelper(string baseUrl)
        {
            BaseURL = baseUrl;
            _client = new RestClient(BaseURL);
        }

        public string BaseURL { get; set; }

        /// <summary>
        /// Method to Execute the Requests and Grab the request
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="type"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public IRestResponse Execute(string resource, Method type, string body = null)
        {
            try
            {
                var request = new RestRequest(resource, type);
                request.AddHeader("Content-Type", "application/json");
                if (!String.IsNullOrEmpty(body))
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = _client.Execute(request);
                 return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured in Executing the Resource: {BaseURL}{resource} {e.Message}");
                return null;
            }
        }
    }
}
