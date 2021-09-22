
namespace Reportium
{
    /// <summary>
    /// Logical connection object
    /// </summary>
    public class Connection
    {
        private string apiKey;
        private string tenant;

        /// <summary>
        /// Create a new connection to Reportium backend
        /// </summary>
        /// <param name="apiKey"> apiKey to use for creating new SSO tokens </param>
        /// <param name="tenant"> Tenant which identifies where tests are reported to </param>
        public Connection(string apiKey, string tenant)
        {
            this.apiKey = apiKey;
            this.tenant = tenant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> apiKey used to generate new SSO tokens </returns>
        public string getApiKey()
        {
            return apiKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> Tenant id to which test executions are reported to </returns>
        public string getTenant()
        {
            return tenant;
        }

    }
}
