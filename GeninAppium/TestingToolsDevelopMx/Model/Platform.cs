using Newtonsoft.Json;

namespace Reportium.model
{
    /// <summary>
    /// Platform class
    /// </summary>
    /// <remarks> Pltaform to be specified in the report </remarks>
    public class DevicePlatform
    {
        [JsonProperty]
        private string deviceId;
        [JsonProperty]
        private string deviceType;
        [JsonProperty]
        private string os;
        [JsonProperty]
        private string osVersion;
        [JsonProperty]
        private string screenResolution;
        [JsonProperty]
        private string location;
        [JsonProperty]
        private MobileInfo mobileInfo;
        [JsonProperty]
        private BrowserInfo browserInfo;

        public DevicePlatform(PlatformBuilder platformBuilder)
        {
            deviceType = platformBuilder.deviceType;
            deviceId = platformBuilder.deviceId;
            os = platformBuilder.os;
            osVersion = platformBuilder.osVersion;
            screenResolution = platformBuilder.screenResolution;
            location = platformBuilder.location;
            mobileInfo = platformBuilder.mobileInfo;
            browserInfo = platformBuilder.browserInfo;
        }

        public string getDeviceId()
        {
            return deviceId;
        }
        public MobileInfo getMobileInfo()
        {
            return mobileInfo;
        }
        public string getDeviceType()
        {
            return deviceType;
        }
        public BrowserInfo getBrowserInfo()
        {
            return browserInfo;
        }
        public string getOs()
        {
            return os;
        }
        public string getOsVersion()
        {
            return osVersion;
        }
        public string getScreenResolution()
        {
            return screenResolution;
        }
        public string getLocation()
        {
            return location;
        }

        /// <summary>
        /// Build a Platform object using a given configuration
        /// </summary>
        public class PlatformBuilder
        {
            internal string deviceType;
            internal string deviceId;
            internal string os;
            internal string osVersion;
            internal string screenResolution;
            internal string location;
            internal MobileInfo mobileInfo;
            internal BrowserInfo browserInfo;

            public PlatformBuilder withDeviceType(DeviceType deviceType)
            {
                this.deviceType = deviceType.ToString();
                return this;
            }

            public PlatformBuilder withDeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            public PlatformBuilder withOs(DeviceOperatingSystem os)
            {
                this.os = os.ToString();
                return this;
            }

            public PlatformBuilder withOsVersion(string osVersion)
            {
                this.osVersion = osVersion;
                return this;
            }

            public PlatformBuilder withScreenResolution(string screenResolution)
            {
                this.screenResolution = screenResolution;
                return this;
            }

            public PlatformBuilder withLocation(string location)
            {
                this.location = location;
                return this;
            }

            public PlatformBuilder withDeviceInfo(MobileInfo mobileInfo)
            {
                this.mobileInfo = mobileInfo;
                return this;
            }

            public PlatformBuilder withBrowserInfo(BrowserInfo browserInfo)
            {
                this.browserInfo = browserInfo;
                return this;
            }

            public DevicePlatform build()
            {
                return new DevicePlatform(this);
            }
        }


        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || this.GetType() != o.GetType()) return false;

            DevicePlatform platform = (DevicePlatform)o;

            if (getDeviceType() != platform.getDeviceType()) return false;
            if (!getOs().Equals(platform.getOs())) return false;
            if (getOsVersion() != null ? !(getOsVersion().Equals(platform.getOsVersion())) : platform.getOsVersion() != null)
                return false;
            if (getScreenResolution() != null ? !getScreenResolution().Equals(platform.getScreenResolution()) : platform.getScreenResolution() != null)
                return false;
            if (getLocation() != null ? !getLocation().Equals(platform.getLocation()) : platform.getLocation() != null)
                return false;
            if (getMobileInfo() != null ? !getMobileInfo().Equals(platform.getMobileInfo()) : platform.getMobileInfo() != null)
                return false;
            return getBrowserInfo() != null ? getBrowserInfo().Equals(platform.getBrowserInfo()) : platform.getBrowserInfo() == null;

        }

        public int hashCode()
        {
            int result = getDeviceType().Equals(DeviceType.DESKTOP) ? getDeviceType().GetHashCode() : 0;
            result = 31 * result + (getOs().GetHashCode());
            result = 31 * result + (getOsVersion() != null ? getOsVersion().GetHashCode() : 0);
            result = 31 * result + (getScreenResolution() != null ? getScreenResolution().GetHashCode() : 0);
            result = 31 * result + (getLocation() != null ? getLocation().GetHashCode() : 0);
            result = 31 * result + (getMobileInfo() != null ? getMobileInfo().GetHashCode() : 0);
            result = 31 * result + (getBrowserInfo() != null ? getBrowserInfo().GetHashCode() : 0);
            return result;
        }
    }
}
