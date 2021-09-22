
using Newtonsoft.Json;

namespace Reportium.model
{

    /// <summary>
    /// Browser info class
    /// </summary>
    /// <remarks> used in the execution context without using mcm </remarks>
    public class BrowserInfo
    {
        [JsonProperty]
        private string browserType;
        [JsonProperty]
        private string browserVersion;

        /// <summary>
        /// Creates new browser info object
        /// </summary>
        /// <param name="browserType">  </param>
        /// <param name="browserVersion"></param>
        public BrowserInfo(BrowserType browserType, string browserVersion)
        {
            this.browserType = browserType.ToString();
            this.browserVersion = browserVersion;
        }

        /// <summary>
        /// Browser type assigned to the browser info
        /// </summary>
        /// <returns> browser type </returns>
        public string getBrowserType()
        {
            return browserType;
        }

        /// <summary>
        /// set the browser type
        /// </summary>
        /// <param name="browserType"> browse type to be assigned </param>
        public void setBrowserType(BrowserType browserType)
        {
            this.browserType = browserType.ToString();
        }

        /// <summary>
        /// Browser version assigned to the browser info
        /// </summary>
        /// <returns> browser version </returns>
        public string getBrowserVersion()
        {
            return browserVersion;
        }

        /// <summary>
        /// set the browser version
        /// </summary>
        /// <param name="browserVersion"> browser version to be assigned</param>
        public void setBrowserVersion(string browserVersion)
        {
            this.browserVersion = browserVersion;
        }
    }
}
