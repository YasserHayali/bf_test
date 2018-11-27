using BF_Test.Interfaces;
using BF_Test.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BF_Test
{
    public class RateClient : IApiClient
    {
        #region Members & Ctors

        private const string DefaultBaseUrl = "https://openexchangerates.org/api/";
        private readonly RestClient _restClient;

        /// <summary>
        /// The API KEY that is used for requests
        /// </summary>
        public string ApiKey { get; set; }

        public RateClient(string apiKey)
        {
            ApiKey = apiKey;
            _restClient = new RestClient(DefaultBaseUrl);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all the latest exchange rates only by USD as default (free plan restriction). 
        /// </summary>
        /// <returns></returns>
        public RateResult GetLatest()
        {
            var request = new RestRequest("latest.json", Method.GET);
            return Execute<RateResult>(request);
        }
        
        #endregion

        private T Execute<T>(IRestRequest request) where T : new()
        {
            request.AddQueryParameter("app_id", ApiKey);

            var response = _restClient.Execute<T>(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (response != null && (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized))
            {
                throw new Exception("Invalid API key or you are not permitted to call this method");
            }
            throw new Exception("Could not get response for one or more reasons");
        }
    }
}
