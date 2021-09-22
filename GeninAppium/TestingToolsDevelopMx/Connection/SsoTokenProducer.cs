using System;
using System.Collections.Generic;
using System.Net.Http;
using Reportium.Model;
using Newtonsoft.Json;
using Reportium.Client;

using static Reportium.Client.Constants.URL;

namespace Reportium
{
    /// <summary>
    /// Creator of single sign on token
    /// </summary>
    internal class SsoTokenProducer
    {

        private Uri apiKeyServer;
        private string apiKey;
        private string tenantId;
        private HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Creates SsoTokenProducer object
        /// </summary>
        /// <param name="apiKeyServer"> Uri of the api key server </param>
        /// <param name="apiKey"> used to create a new sso token </param>
        /// <param name="tenantId"> tenant id which identifies where tests are reported to </param>
        public SsoTokenProducer(Uri apiKeyServer, string apiKey, string tenantId)
        {
            this.apiKeyServer = apiKeyServer;
            this.apiKey = apiKey;
            this.tenantId = tenantId;
        }

        /// <summary>
        /// Produce a new token using the apikeyserver
        /// </summary>
        /// <returns> string token </returns>
        public string getToken()
        {
            //Should combaine apikeyserver with cosnt path string
            Uri resolvedUri = new Uri(apiKeyServer , string.Format(path, tenantId));

            var formParams = new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("client_id", "reportium"),
                new KeyValuePair<string, string>("refresh_token",apiKey)
            };

            var form = new FormUrlEncodedContent(formParams); //By defualt supporting UTF-8

            var response =  httpClient.PostAsync(resolvedUri ,  form).Result.Content.ReadAsStringAsync().Result;
           
            GetTokenResponse getTokenResponse = JsonConvert.DeserializeObject<GetTokenResponse>(response.ToString()); 
            return getTokenResponse.getAccess_token();
        }

        /// <summary>
        /// Class contains the access token
        /// </summary> 
        class GetTokenResponse
        {

            string access_token;

            public GetTokenResponse(string access_token)
            {
                this.access_token = access_token;
            }

            public string getAccess_token()
            {
                return access_token;
            }
        }

}
}
